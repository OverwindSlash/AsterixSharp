using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf7MagneticHeadingAge : FixLengthDataItem
{
    public const int MagneticHeadingAgeLength = 1;
    public const double LSB = 0.25;

    public double Mhg { get; private set; }

    public I062295Sf7MagneticHeadingAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Magnetic Heading Age";
        IsMandatory = false;
        
        LoadRawData(MagneticHeadingAgeLength, buffer, offset);

        var mhgValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Mhg = mhgValue * LSB;
    }
}