using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf2CallSign : FixLengthDataItem
{
    public const int CallSignLength = 7;

    public I062390Sf2CallSign(byte[] buffer, int offset)
    {
        Name = "I062/390, Call Sign";
        IsMandatory = false;
        
        LoadRawData(CallSignLength, buffer, offset);
        
        // TODO
    }
}