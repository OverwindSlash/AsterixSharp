using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062510ComposedTrackNumber : ExtentableDataItem
{
    public const int MaxComposedTrackNumberLength = 6;
    
    public I062510ComposedTrackNumber(byte[] buffer, int offset)
    {
        Name = "I062/510, Composed Track Number";
        IsMandatory = false;
        
        ParseExtentableData(MaxComposedTrackNumberLength, buffer, offset);
        
        // TODO
    }
}