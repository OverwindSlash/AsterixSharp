using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf7DepartureAirport : FixLengthDataItem
{
    public const int DepartureAirportLength = 4;

    public I062390Sf7DepartureAirport(byte[] buffer, int offset)
    {
        Name = "I062/390, Departure Airport";
        IsMandatory = false;
        
        LoadRawData(DepartureAirportLength, buffer, offset);
        
        // TODO
    }
}