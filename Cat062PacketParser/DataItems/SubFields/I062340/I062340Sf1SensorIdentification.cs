using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf1SensorIdentification : FixLengthDataItem
{
    public const int SensorIdentificationLength = 2;

    public byte SystemAreaCode { get; private set; }
    public byte SystemIdentificationCode { get; private set; }

    public I062340Sf1SensorIdentification(byte[] buffer, int offset)
    {
        Name = "I062/340, Sensor Identification";
        IsMandatory = false;
        
        LoadRawData(SensorIdentificationLength, buffer, offset);

        SystemAreaCode = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        SystemIdentificationCode = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 8);
    }
}