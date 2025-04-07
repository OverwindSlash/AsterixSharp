using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf13AircraftStand : FixLengthDataItem
{
    public const int AircraftStandLength = 6;

    public I062390Sf13AircraftStand(byte[] buffer, int offset)
    {
        Name = "I062/380, Aircraft Stand";
        IsMandatory = false;
        
        LoadRawData(AircraftStandLength, buffer, offset);
        
        // TODO
    }
}