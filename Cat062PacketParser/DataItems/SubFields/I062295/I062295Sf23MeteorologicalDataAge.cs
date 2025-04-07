using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf23MeteorologicalDataAge : FixLengthDataItem
{
    public const int MeteorologicalAgeLength = 1;

    public I062295Sf23MeteorologicalDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Meteorological Data Age";
        IsMandatory = false;
        
        LoadRawData(MeteorologicalAgeLength, buffer, offset);
        
        // TODO
    }
}