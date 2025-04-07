using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackPositionInCartesianLength = 4;

    public I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Position (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackPositionInCartesianLength, buffer, offset);
        
        // TODO
    }
}