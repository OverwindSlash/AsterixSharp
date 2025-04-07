using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf14StatusReportedByAdsBAge : FixLengthDataItem
{
    public const int StatusReportedByAdsBAgeLength = 1;
    public const double LSB = 0.25;

    public double Sab { get; private set; }

    public I062295Sf14StatusReportedByAdsBAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Status Reported By ADS-B Age";
        IsMandatory = false;
        
        LoadRawData(StatusReportedByAdsBAgeLength, buffer, offset);

        var sabValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Sab = sabValue * LSB;
    }
}