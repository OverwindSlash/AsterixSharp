using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062290Sf2PsrAge : FixLengthDataItem
{
    public const int PsrAgeLength = 1;

    public I062290Sf2PsrAge(byte[] buffer, int offset)
    {
        Name = "I062/290, PSR Age";
        IsMandatory = false;
        
        LoadRawData(PsrAgeLength, buffer, offset);
        
        // TODO
    }
}