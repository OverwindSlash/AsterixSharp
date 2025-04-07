using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062290Sf5AdscAge : FixLengthDataItem
{
    public const int AdscAgeLength = 2;

    public I062290Sf5AdscAge(byte[] buffer, int offset)
    {
        Name = "I062/290, ADS-C Age";
        IsMandatory = false;
        
        LoadRawData(AdscAgeLength, buffer, offset);
        
        // TODO
    }
}