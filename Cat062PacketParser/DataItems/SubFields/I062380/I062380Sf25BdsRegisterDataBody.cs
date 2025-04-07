using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf25BdsRegisterDataBody : FixLengthDataItem
{
    public int BdsRegisterDataBodyLength = 9;

    public I062380Sf25BdsRegisterDataBody(byte[] buffer, int offset)
    {
        Name = "I062/380, BDS Register Data";
        IsMandatory = false;
        
        LoadRawData(BdsRegisterDataBodyLength, buffer, offset);
        
        // TODO
    }
}