using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf23GeometricAltitude : FixLengthDataItem
{
    public const int GeometricAltitudeLength = 2;

    public I062380Sf23GeometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/380, Geometric Altitude";
        IsMandatory = false;
        
        LoadRawData(GeometricAltitudeLength, buffer, offset);
        
        // TODO
    }
}