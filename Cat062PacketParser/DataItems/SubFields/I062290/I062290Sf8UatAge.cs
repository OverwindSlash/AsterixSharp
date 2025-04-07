using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf8UatAge : FixLengthDataItem
{
    public const int UatAgeLength = 1;
    public const double LSB = 0.25;

    public double Uat { get; private set; }

    public I062290Sf8UatAge(byte[] buffer, int offset)
    {
        Name = "I062/290, UAT Age";
        IsMandatory = false;
        
        LoadRawData(UatAgeLength, buffer, offset);
        
        var uatValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Uat = uatValue * LSB;
    }
}