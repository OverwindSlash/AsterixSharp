using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf8IndicatedAirspeedAge : FixLengthDataItem
{
    public const int IndicatedAirspeedAgeLength = 1;

    public I062295Sf8IndicatedAirspeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Indicated Airspeed Age";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedAgeLength, buffer, offset);
        
        // TODO
    }
}