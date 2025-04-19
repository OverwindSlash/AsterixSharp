using Utils;

namespace Cat240PacketParser
{
    public class Cat240Header
    {
        private const int BitsPerByte = 8;
        private const int FieldSpecTotalBits = 16;

        public byte Category { get; private set; }
        public ushort DataBlockLength { get; private set; }
        public List<bool> FieldSpecFlags { get; private set; }
        public int Offset { get; private set; }

        public Cat240Header(byte[] buffer)
        {
            Offset = 0;

            // CAT 标志位，1 byte
            Category = buffer[Offset++];
            if (Category != 0xF0)
            {
                throw new InvalidOperationException("Invalid package header: Category mismatch.");
            }

            // Data block 长度，2 bytes
            DataBlockLength = BitOperations.Get2BytesUnSignedBigEndian(buffer, Offset);
            Offset += 2;

            // 解析 FieldSpec
            FieldSpecFlags = [];
            bool fx = true;

            while (fx)
            {
                int bitOffset = Offset * BitsPerByte;
                for (int i = 0; i < 8; i++)
                {
                    FieldSpecFlags.Add(BitOperations.GetBit(buffer, bitOffset + i));
                }

                fx = FieldSpecFlags.Last();
                Offset++;
            }

            // 补全后续的空缺项
            for (int i = FieldSpecFlags.Count; i < FieldSpecTotalBits; i++)
            {
                FieldSpecFlags.Add(false);
            }
        }

        public bool HasDataSourceIdentifier => FieldSpecFlags[0];
        public bool HasMessageType => FieldSpecFlags[1];
        public bool HasVideoRecordHeader => FieldSpecFlags[2];
        public bool HasVideoSummary => FieldSpecFlags[3];
        public bool HasVideoHeaderNano => FieldSpecFlags[4];
        public bool HasVideoHeaderFemto => FieldSpecFlags[5];
        public bool HasVideoCellsResolutionDataCompressionIndicator => FieldSpecFlags[6];
        public bool Fx1 => FieldSpecFlags[7];

        public bool HasVideoOctetsVideoCellsCounters => Fx1 && FieldSpecFlags[8];
        public bool HasVideoBlockLowDataVolume => Fx1 && FieldSpecFlags[9];
        public bool HasVideoBlockMediumDataVolume => Fx1 && FieldSpecFlags[10];
        public bool HasVideoBlockHighDataVolume => Fx1 && FieldSpecFlags[11];
        public bool HasTimeOfDay => Fx1 && FieldSpecFlags[12];
        public bool HasReservedExpansionField => Fx1 && FieldSpecFlags[13];
        public bool HasSpecialPurposeField => Fx1 && FieldSpecFlags[14];
        public bool Fx2 => Fx1 && FieldSpecFlags[15];
    }
}
