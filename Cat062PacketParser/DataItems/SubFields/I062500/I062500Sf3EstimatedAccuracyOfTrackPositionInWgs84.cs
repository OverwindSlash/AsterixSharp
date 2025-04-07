using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84 : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackPositionInWgs84Length = 4;

    public I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Position (WGS-84)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackPositionInWgs84Length, buffer, offset);
        
        // TODO
    }
}