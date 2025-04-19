using System.Text;
using Utils;

namespace Cat240PacketParser
{
    public class Cat240DataItems
    {
        
        private const double AzimuthUnit = 360.0 / 65536;

        public byte SystemAreaCode { get; private set; }
        public byte SystemIdentificationCode { get; private set; }
        public byte MessageType { get; private set; }
        public uint MessageIndex { get; private set; }
        public string VideoSummary { get; private set; } = string.Empty;
        public ushort StartAzimuth { get; private set; }
        public double StartAzimuthInDegree => StartAzimuth * AzimuthUnit;
        public ushort EndAzimuth { get; private set; }
        public double EndAzimuthInDegree => EndAzimuth * AzimuthUnit;
        public uint StartRange { get; private set; }
        public uint CellDuration { get; private set; }
        public double VideoCellDurationUnit { get; private set; }
        public bool IsDataCompressed { get; private set; }
        public byte VideoResolution { get; private set; }
        public ushort ValidBytesInDataBlock { get; private set; }
        public uint ValidCellsInDataBlock { get; private set; }
        public byte VideoBlockCount { get; private set; }
        public ushort VideoBlockLength { get; private set; }
        public ReadOnlyMemory<byte> VideoBlocks { get; private set; }
        public uint TimeOfDay { get; private set; }
        public double TimeOfDayInSec { get; private set; }

        public byte[] _videoBlocksBuffer;

        public Cat240DataItems(Cat240Header header, byte[] buffer, int size)
        {
            int offset = header.Offset;

            // Data source identifier, 2 bytes (SAC / SIC)
            if (header.HasDataSourceIdentifier)
            {
                SystemAreaCode = buffer[offset++];
                SystemIdentificationCode = buffer[offset++];
            }

            // Message type, 1 byte (001-Summary, 002-Video)
            if (header.HasMessageType)
            {
                MessageType = buffer[offset++];
            }

            // Message index, 4 bytes
            if (header.HasVideoRecordHeader)
            {
                MessageIndex = (uint)BitOperations.Get4BytesUnSignedBigEndian(buffer, offset);
                offset += 4;
            }

            // Video summary, 1 + n bytes
            if (header.HasVideoSummary)
            {
                byte charCount = buffer[offset++];

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < charCount; i++)
                {
                    sb.Append(buffer[offset++]);
                }

                VideoSummary = sb.ToString();
            }

            // Video header (Nano or Femto)
            VideoCellDurationUnit = 1e-15;
            if (header.HasVideoHeaderNano)
            {
                VideoCellDurationUnit = 1e-9;
            }

            // Start azimuth, 2 bytes, 单位：360/2^16
            StartAzimuth = BitOperations.Get2BytesUnSignedBigEndian(buffer, offset);
            offset += 2;

            // End azimuth, 2 bytes, 单位：360/2^16
            EndAzimuth = BitOperations.Get2BytesUnSignedBigEndian(buffer, offset);
            offset += 2;

            // Start range, 4 bytes
            StartRange = BitOperations.Get4BytesUnSignedBigEndian(buffer, offset);
            offset += 4;

            // Cell duration, 4 bytes (Nano or Femto)
            CellDuration = BitOperations.Get4BytesUnSignedBigEndian(buffer, offset);
            offset += 4;

            // Data compression indicator, 1 byte
            if (header.HasVideoCellsResolutionDataCompressionIndicator)
            {
                byte compress_flag = buffer[offset++];
                IsDataCompressed = (compress_flag == 0b10000000);

                byte resolution_flag = buffer[offset++];
                switch (resolution_flag)
                {
                    case 1:
                        VideoResolution = 1;
                        break;
                    case 2:
                        VideoResolution = 2;
                        break;
                    case 3:
                        VideoResolution = 4;
                        break;
                    case 4:
                        VideoResolution = 8;
                        break;
                    case 5:
                        VideoResolution = 16;
                        break;
                    case 6:
                        VideoResolution = 32;
                        break;
                }
            }

            // Valid video bytes and cells
            if (header.HasVideoOctetsVideoCellsCounters)
            {
                // Valid bytes in Video block data, 2 bytes
                ValidBytesInDataBlock = BitOperations.Get2BytesUnSignedBigEndian(buffer, offset);
                offset += 2;

                // Valid cells in Video block data, 3 bytes
                ValidCellsInDataBlock = BitOperations.Get3BytesUnSignedBigEndian(buffer, offset);
                offset += 3;
            }

            // Video block data volume count, 1 byte
            VideoBlockCount = buffer[offset++];
            if (header.HasVideoBlockLowDataVolume)
            {
                // Video block low data volume, 4 * n bytes
                VideoBlockLength = 4;
            }
            else if (header.HasVideoBlockMediumDataVolume)
            {
                // Video block medium data volume, 64 * n bytes
                VideoBlockLength = 64;
            }
            else if (header.HasVideoBlockHighDataVolume)
            {
                // Video block medium data volume, 256 * n bytes
                VideoBlockLength = 256;
            }

            int totalLength = VideoBlockCount * VideoBlockLength;
            VideoBlocks = buffer.AsMemory(offset, totalLength);
            _videoBlocksBuffer = VideoBlocks.ToArray();
            offset += totalLength;

            // Time of day, 3 bytes, 单位 1/128 s
            if (header.HasTimeOfDay)
            {
                TimeOfDay = BitOperations.Get3BytesUnSignedBigEndian(buffer, offset);
                offset += 3;

                TimeOfDayInSec = TimeOfDay / 128.0;
            }
        }

        public uint GetCellData(int cellIndex)
        {
            switch (VideoResolution)
            {
                case 1:
                    bool cell1Bit = BitOperations.GetBit(_videoBlocksBuffer, cellIndex);
                    return cell1Bit ? (uint)1 : 0;
                case 2:
                    byte cell2Bits = (byte)BitOperations.ConvertBitsBigEndianUnsigned(_videoBlocksBuffer, cellIndex * 2, 2);
                    return (uint)cell2Bits;
                case 4:
                    byte cell4Bits = (byte)BitOperations.ConvertBitsBigEndianUnsigned(_videoBlocksBuffer, cellIndex * 4, 4);
                    return (uint)cell4Bits;
                case 8:
                    byte cell1Byte = _videoBlocksBuffer[cellIndex];
                    return (uint)cell1Byte;
                case 16:
                    ushort cell2Bytes = BitOperations.Get2BytesUnSignedBigEndian(_videoBlocksBuffer, cellIndex * 2);
                    return (uint)cell2Bytes;
                case 32:
                    uint cell4Bytes = BitOperations.Get4BytesUnSignedBigEndian(_videoBlocksBuffer, cellIndex * 4);
                    return cell4Bytes;
                default:
                    byte cellDefault = _videoBlocksBuffer[cellIndex];
                    return (uint)cellDefault;
            }
        }

        public bool IsSpecChanged(Cat240DataItems other)
        {
            if (other == null)
            {
                return true;
            }

            if (this.CellDuration != other.CellDuration
                || this.VideoCellDurationUnit != other.VideoCellDurationUnit
                || this.IsDataCompressed != other.IsDataCompressed
                || this.VideoResolution != other.VideoResolution
                || this.ValidBytesInDataBlock != other.ValidBytesInDataBlock
                || this.ValidCellsInDataBlock != other.ValidCellsInDataBlock
                || this.VideoBlockLength != other.VideoBlockLength)
            {
                return true;
            }

            return false;
        }
    }
}
