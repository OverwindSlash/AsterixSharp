using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf9LoopAge : FixLengthDataItem
{
    public const int LoopAgeLength = 1;

    public I062290Sf9LoopAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Loop Age";
        IsMandatory = false;
        
        LoadRawData(LoopAgeLength, buffer, offset);
        
        // TODO
    }
}