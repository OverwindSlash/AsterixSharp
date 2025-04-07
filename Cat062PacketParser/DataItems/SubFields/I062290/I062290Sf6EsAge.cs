using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf6EsAge : FixLengthDataItem
{
    public const int EsAgeLength = 1;

    public I062290Sf6EsAge(byte[] buffer, int offset)
    {
        Name = "I062/290, ES Age";
        IsMandatory = false;
        
        LoadRawData(EsAgeLength, buffer, offset);
        
        // TODO
    }
}