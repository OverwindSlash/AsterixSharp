using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84 : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackPositionInWgs84Length = 4;
    public const double LSB = 0.00000536441802978515625;

    public double ApwLatitude { get; private set; }
    public double ApwLongitude { get; private set; }

    public I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Position (WGS-84)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackPositionInWgs84Length, buffer, offset);

        var latValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        var lonValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 16, 16);

        ApwLatitude = latValue * LSB;
        ApwLongitude = lonValue * LSB;
    }
}