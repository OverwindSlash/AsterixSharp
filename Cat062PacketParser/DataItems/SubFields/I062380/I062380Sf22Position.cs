using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf22Position : FixLengthDataItem
{
    public const int PositionLength = 6;

    public I062380Sf22Position(byte[] buffer, int offset)
    {
        Name = "I062/380, Position";
        IsMandatory = false;
        
        LoadRawData(PositionLength, buffer, offset);
        
        // TODO
    }
}