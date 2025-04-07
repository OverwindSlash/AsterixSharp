using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf12TimeOfDepartureArrivalBody : FixLengthDataItem
{
    public const int TimeOfDepartureArrivalBodyLength = 4;

    public I062390Sf12TimeOfDepartureArrivalBody(byte[] buffer, int offset)
    {
        Name = "I062/390, Time of Departure Arrival Body";
        IsMandatory = false;
        
        LoadRawData(TimeOfDepartureArrivalBodyLength, buffer, offset);
        
        // TODO
    }
}