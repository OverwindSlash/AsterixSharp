using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf26IndicatedAirspeed : FixLengthDataItem
{
    public const int IndicatedAirspeedLength = 2;

    public I062380Sf26IndicatedAirspeed(byte[] buffer, int offset)
    {
        Name = "I062/380, Indicated Airspeed";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedLength, buffer, offset);
        
        // TODO
    }
}