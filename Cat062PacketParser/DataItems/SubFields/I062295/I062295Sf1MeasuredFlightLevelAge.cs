using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf1MeasuredFlightLevelAge : FixLengthDataItem
{
    public const int MeasuredFlightLevelAgeLength = 1;
    public const double LSB = 0.25;

    public double Mfl { get; private set; }

    public I062295Sf1MeasuredFlightLevelAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Measured Flight Level Age";
        IsMandatory = false;
        
        LoadRawData(MeasuredFlightLevelAgeLength, buffer, offset);
        
        var mflValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Mfl = mflValue * LSB;
    }
}