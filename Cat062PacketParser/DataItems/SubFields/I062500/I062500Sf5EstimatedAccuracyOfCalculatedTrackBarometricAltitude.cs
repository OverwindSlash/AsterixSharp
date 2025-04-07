using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf4EstimatedAccuracyOfCalculatedTrackBarometricAltitude : FixLengthDataItem
{
    public const int EstimatedAccuracyOfCalculatedTrackBarometricAltitudeLength = 1;

    public I062500Sf4EstimatedAccuracyOfCalculatedTrackBarometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Calculated Track Barometric Altitude";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfCalculatedTrackBarometricAltitudeLength, buffer, offset);
        
        // TODO
    }
}