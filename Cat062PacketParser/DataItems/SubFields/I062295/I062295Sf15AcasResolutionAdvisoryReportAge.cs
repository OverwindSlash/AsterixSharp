using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf15AcasResolutionAdvisoryReportAge : FixLengthDataItem
{
    public const int AcasResolutionAdvisoryReportAgeLength = 1;
    public const double LSB = 0.25;

    public double Acs { get; private set; }

    public I062295Sf15AcasResolutionAdvisoryReportAge(byte[] buffer, int offset)
    {
        Name = "I062/295, ACAS Resolution Advisory Report Age";
        IsMandatory = false;
        
        LoadRawData(AcasResolutionAdvisoryReportAgeLength, buffer, offset);

        var acsValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Acs = acsValue * LSB;
    }
}