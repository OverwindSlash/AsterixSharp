using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf12AcasResolutionAdvisoryReport : FixLengthDataItem
{
    public const int AcasResolutionAdvisoryReportLength = 7;

    public I062380Sf12AcasResolutionAdvisoryReport(byte[] buffer, int offset)
    {
        Name = "I062/380, Acas Resolution Advisory Report";
        IsMandatory = false;
        
        LoadRawData(AcasResolutionAdvisoryReportLength, buffer, offset);
        
        // TODO
    }
}