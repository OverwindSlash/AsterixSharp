using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf4ModeSAge : FixLengthDataItem
{
    public const int ModeSAgeLength = 1;
    public const double LSB = 0.25;

    public double ModeS { get; private set; }

    public I062290Sf4ModeSAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Mode S Age";
        IsMandatory = false;
        
        LoadRawData(ModeSAgeLength, buffer, offset);

        var mdsValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        ModeS = mdsValue * LSB;
    }
}