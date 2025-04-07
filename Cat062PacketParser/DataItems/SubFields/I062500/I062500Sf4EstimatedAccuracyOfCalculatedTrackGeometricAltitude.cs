using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude : FixLengthDataItem
{
    public const int EstimatedAccuracyOfCalculatedTrackGeometricAltitudeLength = 1;

    public I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Calculated Track Geometric Altitude";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfCalculatedTrackGeometricAltitudeLength, buffer, offset);
        
        // TODO
    }
}