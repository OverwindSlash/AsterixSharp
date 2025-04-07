using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackVelocityInCartesianLength = 2;

    public I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Velocity (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackVelocityInCartesianLength, buffer, offset);
        
        // TODO
    }
}