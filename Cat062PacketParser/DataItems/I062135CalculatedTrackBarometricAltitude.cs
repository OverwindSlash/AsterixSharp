using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062135CalculatedTrackBarometricAltitude : FixLengthDataItem
{
    public const int CalculatedTrackBarometricAltitudeLength = 2;

    public I062135CalculatedTrackBarometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/135, Calculated Track Barometric Altitude";
        IsMandatory = false;
        
        LoadRawData(CalculatedTrackBarometricAltitudeLength, buffer, offset);
        
        // TODO
    }
}