using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf11StatusReportedByAdsB : FixLengthDataItem
{
    public const int StatusReportedByAdsBLength = 2;

    public I062380Sf11StatusReportedByAdsB(byte[] buffer, int offset)
    {
        Name = "I062/380, Status Reported By Ads B Data";
        IsMandatory = false;
    }
}