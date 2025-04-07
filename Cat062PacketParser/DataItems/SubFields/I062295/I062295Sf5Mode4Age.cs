using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf5Mode4Age : FixLengthDataItem
{
    public const int Mode4AgeLength = 1;
    public const double LSB = 0.25;

    public double Md4 { get; private set; }

    public I062295Sf5Mode4Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 4 Age";
        IsMandatory = false;
        
        LoadRawData(Mode4AgeLength, buffer, offset);

        var md4Value = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Md4 = md4Value * LSB;
    }
}