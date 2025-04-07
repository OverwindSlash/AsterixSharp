using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf2Mode1Age : FixLengthDataItem
{
    public const int Mode1AgeLength = 1;
    public const double LSB = 0.25;

    public double Md1 { get; private set; }

    public I062295Sf2Mode1Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 1 Age";
        IsMandatory = false;
        
        LoadRawData(Mode1AgeLength, buffer, offset);

        var md1Value = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Md1 = md1Value * LSB;
    }
}