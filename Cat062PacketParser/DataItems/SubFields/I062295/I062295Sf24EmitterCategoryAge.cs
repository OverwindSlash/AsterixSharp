using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf24EmitterCategoryAge : FixLengthDataItem
{
    public const int EmitterCategoryAgeLength = 1;

    public I062295Sf24EmitterCategoryAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Emitter Category Age";
        IsMandatory = false;
        
        LoadRawData(EmitterCategoryAgeLength, buffer, offset);
        
        // TODO
    }
}