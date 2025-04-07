using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf6ReportType : FixLengthDataItem
{
    public enum ReportTypes
    {
        NoDetection = 0,
        SinglePsrDetection = 1,
        SingleSsrDetection = 2,
        SsrPsrDetection = 3,
        SingleModeSAllCall = 4,
        SingleModeSRollCall = 5,
        ModeSAllCallPsr = 6,
        ModeSRollCallPsr = 7,
    }
    
    public const int ReportTypeLength = 1;
    
    public ReportTypes Type { get; private set; }
    public bool IsSimulatedTargetReport { get; private set; }
    public bool IsReportFromFieldMonitor { get; private set; }
    public bool IsTestTargetReport { get; private set; }

    public I062340Sf6ReportType(byte[] buffer, int offset)
    {
        Name = "I062/340, Report Type";
        IsMandatory = false;
        
        LoadRawData(ReportTypeLength, buffer, offset);

        Type = (ReportTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 3);
        IsSimulatedTargetReport = BitOperations.GetBit(RawData, 3);
        IsReportFromFieldMonitor = BitOperations.GetBit(RawData, 4);
        IsTestTargetReport = BitOperations.GetBit(RawData, 5);
    }
}