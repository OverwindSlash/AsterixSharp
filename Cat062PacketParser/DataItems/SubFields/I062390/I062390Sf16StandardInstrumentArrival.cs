using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf16StandardInstrumentArrival : FixLengthDataItem
{
    public const int StandardInstrumentArrivalLength = 7;

    public I062390Sf16StandardInstrumentArrival(byte[] buffer, int offset)
    {
        Name = "I062/390, Standard Instrument Arrival";
        IsMandatory = false;
        
        LoadRawData(StandardInstrumentArrivalLength, buffer, offset);
        
        // TODO
    }
}