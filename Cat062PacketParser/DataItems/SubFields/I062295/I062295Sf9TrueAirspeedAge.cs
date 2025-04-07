using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf9TrueAirspeedAge : FixLengthDataItem
{
    public const int TrueAirspeedAgeLength = 1;

    public I062295Sf9TrueAirspeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, True Airspeed Age";
        IsMandatory = false;
        
        LoadRawData(TrueAirspeedAgeLength, buffer, offset);
        
        // TODO
    }
}