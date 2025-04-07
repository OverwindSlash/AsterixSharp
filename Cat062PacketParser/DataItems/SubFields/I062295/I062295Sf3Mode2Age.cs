using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf3Mode2Age : FixLengthDataItem
{
    public const int Mode2AgeLength = 1;

    public I062295Sf3Mode2Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 2 Age";
        IsMandatory = false;
        
        LoadRawData(Mode2AgeLength, buffer, offset);
        
        // TODO
    }
}