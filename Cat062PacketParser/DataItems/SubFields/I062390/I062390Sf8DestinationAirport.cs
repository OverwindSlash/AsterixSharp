using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf8DestinationAirport : FixLengthDataItem
{
    public const int DestinationAirportLength = 4;

    public I062390Sf8DestinationAirport(byte[] buffer, int offset)
    {
        Name = "I062/390, Destination Airport";
        IsMandatory = false;
        
        LoadRawData(DestinationAirportLength, buffer, offset);
        
        // TODO
    }
}