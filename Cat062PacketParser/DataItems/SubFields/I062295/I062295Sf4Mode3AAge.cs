using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf4Mode3AAge : FixLengthDataItem
{
    public const int Mode3AAgeLength = 1;

    public I062295Sf4Mode3AAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 3/A Age";
        IsMandatory = false;
        
        LoadRawData(Mode3AAgeLength, buffer, offset);
        
        // TODO
    }
}