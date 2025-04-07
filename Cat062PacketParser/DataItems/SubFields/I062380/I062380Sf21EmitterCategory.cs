using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf21EmitterCategory : FixLengthDataItem
{
    public const int EmitterCategoryLength = 1;

    public I062380Sf21EmitterCategory(byte[] buffer, int offset)
    {
        Name = "I062/380, Emitter Category";
        IsMandatory = false;
        
        LoadRawData(EmitterCategoryLength, buffer, offset);
        
        // TODO
    }
}