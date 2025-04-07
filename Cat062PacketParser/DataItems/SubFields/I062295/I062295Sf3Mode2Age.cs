using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf3Mode2Age : FixLengthDataItem
{
    public const int Mode2AgeLength = 1;
    public const double LSB = 0.25;

    public double Md2 { get; private set; }

    public I062295Sf3Mode2Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 2 Age";
        IsMandatory = false;
        
        LoadRawData(Mode2AgeLength, buffer, offset);

        var md2Value = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Md2 = md2Value * LSB;
    }
}