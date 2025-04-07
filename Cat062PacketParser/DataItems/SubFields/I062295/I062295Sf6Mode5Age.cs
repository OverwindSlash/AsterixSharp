using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf6Mode5Age : FixLengthDataItem
{
    public const int Mode5AgeLength = 1;

    public I062295Sf6Mode5Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 5 Age";
        IsMandatory = false;
        
        LoadRawData(Mode5AgeLength, buffer, offset);
    }
}