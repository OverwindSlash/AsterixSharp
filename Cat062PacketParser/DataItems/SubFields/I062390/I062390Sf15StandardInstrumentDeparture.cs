using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf15StandardInstrumentDeparture : FixLengthDataItem
{
    public const int StandardInstrumentDepartureLength = 7;

    public I062390Sf15StandardInstrumentDeparture(byte[] buffer, int offset)
    {
        Name = "I062/390, Standard Instrument Departure";
        IsMandatory = false;
        
        LoadRawData(StandardInstrumentDepartureLength, buffer, offset);
        
        // TODO
    }
}