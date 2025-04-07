using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf25PositionAge : FixLengthDataItem
{
    public const int PositionAgeLength = 1;

    public I062295Sf25PositionAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Position Age";
        IsMandatory = false;
        
        LoadRawData(PositionAgeLength, buffer, offset);
        
        // TODO
    }
}