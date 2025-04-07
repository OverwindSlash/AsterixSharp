using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf4ModeSAge : FixLengthDataItem
{
    public const int ModeSAgeLength = 1;

    public I062290Sf4ModeSAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Mode S Age";
        IsMandatory = false;
        
        LoadRawData(ModeSAgeLength, buffer, offset);
        
        // TODO
    }
}