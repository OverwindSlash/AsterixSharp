using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf3MagneticHeading : FixLengthDataItem
{
    public const int MagneticHeadingLength = 2;
    public const double LSB = 0.00549316;
    
    public double MagneticHeading { get; private set; }

    public I062380Sf3MagneticHeading(byte[] buffer, int offset)
    {
        Name = "I062/380, Magnetic Heading";
        IsMandatory = false;
        
        LoadRawData(MagneticHeadingLength, buffer, offset);

        var mhgValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        MagneticHeading = mhgValue * LSB;
    }
}