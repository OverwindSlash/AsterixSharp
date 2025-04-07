using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf26GeometricAltitudeAge : FixLengthDataItem
{
    public const int GeometricAltitudeAgeLength = 1;

    public I062295Sf26GeometricAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Geometric Altitude Age";
        IsMandatory = false;
        
        LoadRawData(GeometricAltitudeAgeLength, buffer, offset);
        
        // TODO
    }
}