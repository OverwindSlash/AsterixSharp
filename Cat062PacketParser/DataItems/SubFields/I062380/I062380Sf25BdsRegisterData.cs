using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf25BdsRegisterData : RepeatableDataItem
{
    public const int BdsRegisterDataRepeatCountLength = 1;
    
    public List<I062380Sf25BdsRegisterDataBody> BdsRegisterDataItems = new();

    public I062380Sf25BdsRegisterData(byte[] buffer, int offset)
    {
        Name = "I062/380, BDS Register Data";
        IsMandatory = false;
        
        LoadRepeatCountItem(BdsRegisterDataRepeatCountLength, buffer, offset);
        offset += BdsRegisterDataRepeatCountLength;
        
        for (int i = 0; i < RepeatCount; i++)
        {
            var body = new I062380Sf25BdsRegisterDataBody(buffer, offset);
            BdsRegisterDataItems.Add(body);
            offset += body.Length;
        }
    }
}