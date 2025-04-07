using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf10MultilaterationAge : FixLengthDataItem
{
    public const int MultilaterationAgeLength = 1;

    public I062290Sf10MultilaterationAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Multilateration Age";
        IsMandatory = false;
        
        LoadRawData(MultilaterationAgeLength, buffer, offset);
        
        // TODO
    }
}