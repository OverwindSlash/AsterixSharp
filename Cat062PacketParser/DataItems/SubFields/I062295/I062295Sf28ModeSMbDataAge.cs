using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf28ModeSMbDataAge : FixLengthDataItem
{
    public const int ModeSMbDataAgeLength = 1;

    public I062295Sf28ModeSMbDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode S MB Data Age";
        IsMandatory = false;
        
        LoadRawData(ModeSMbDataAgeLength, buffer, offset);
        
        // TODO
    }
}