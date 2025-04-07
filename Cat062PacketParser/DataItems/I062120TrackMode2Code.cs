using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062120TrackMode2Code : FixLengthDataItem
{
    public const int TrackMode2CodeLength = 2;

    public I062120TrackMode2Code(byte[] buffer, int offset)
    {
        Name = "I062/120, Track Mode 2 Code";
        IsMandatory = false;
        
        LoadRawData(TrackMode2CodeLength, buffer, offset);
        
        // TODO
    }
}