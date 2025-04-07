using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf4Mode5GnssDerivedAltitude : FixLengthDataItem
{
    public const int Mode5GnssDerivedAltitudeLength = 2;

    public I062110Sf4Mode5GnssDerivedAltitude(byte[] buffer, int offset)
    {
        Name = "I062/110, Mode 5 GNSS-derived Altitude";
        IsMandatory = false;
        
        LoadRawData(Mode5GnssDerivedAltitudeLength, buffer, offset);
        
        // TODO
    }
}