using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf29IndicatedAirspeedDataAge : FixLengthDataItem
{
    public const int IndicatedAirspeedDataAgeLength = 1;

    public I062295Sf29IndicatedAirspeedDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Indicated Airspeed Data Age";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedDataAgeLength, buffer, offset);
        
        // TODO
    }
}