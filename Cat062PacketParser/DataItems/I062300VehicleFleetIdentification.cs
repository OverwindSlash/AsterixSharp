using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062300VehicleFleetIdentification : FixLengthDataItem
{
    public const int VehicleFleetIdentificationLength = 1;

    public I062300VehicleFleetIdentification(byte[] buffer, int offset)
    {
        Name = "I062/300, Vehicle Fleet Identification";
        IsMandatory = false;
        
        LoadRawData(VehicleFleetIdentificationLength, buffer, offset);
        
        // TODO
    }
}