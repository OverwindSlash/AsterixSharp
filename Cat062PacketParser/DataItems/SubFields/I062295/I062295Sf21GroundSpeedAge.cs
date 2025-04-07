using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf21GroundSpeedAge : FixLengthDataItem
{
    public const int GroundSpeedAgeLength = 1;

    public I062295Sf21GroundSpeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Ground Speed Age";
        IsMandatory = false;
        
        LoadRawData(GroundSpeedAgeLength, buffer, offset);
        
        // TODO
    }
}