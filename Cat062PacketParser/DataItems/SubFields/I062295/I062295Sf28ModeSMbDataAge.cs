using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf28ModeSMbDataAge : FixLengthDataItem
{
    public const int ModeSMbDataAgeLength = 1;
    public const double LSB = 0.25;

    public double Mb { get; private set; }

    public I062295Sf28ModeSMbDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode S MB Data Age";
        IsMandatory = false;
        
        LoadRawData(ModeSMbDataAgeLength, buffer, offset);

        var mbValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Mb = mbValue * LSB;
    }
}