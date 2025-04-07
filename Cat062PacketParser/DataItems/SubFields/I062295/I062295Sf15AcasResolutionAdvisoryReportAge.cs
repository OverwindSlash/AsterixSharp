using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf15AcasResolutionAdvisoryReportAge : FixLengthDataItem
{
    public const int AcasResolutionAdvisoryReportAgeLength = 1;

    public I062295Sf15AcasResolutionAdvisoryReportAge(byte[] buffer, int offset)
    {
        Name = "I062/295, ACAS Resolution Advisory Report Age";
        IsMandatory = false;
        
        LoadRawData(AcasResolutionAdvisoryReportAgeLength, buffer, offset);
        
        // TODO
    }
}