using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062290Sf8UatAge : FixLengthDataItem
{
    public const int UatAgeLength = 1;

    public I062290Sf8UatAge(byte[] buffer, int offset)
    {
        Name = "I062/290, UAT Age";
        IsMandatory = false;
        
        LoadRawData(UatAgeLength, buffer, offset);
        
        // TODO
    }
}