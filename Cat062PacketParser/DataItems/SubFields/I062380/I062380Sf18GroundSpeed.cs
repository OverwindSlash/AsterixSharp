using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf18GroundSpeed : FixLengthDataItem
{
    public const int GroundSpeedLength = 2;

    public I062380Sf18GroundSpeed(byte[] buffer, int offset)
    {
        Name = "I062/380, Ground Speed";
        IsMandatory = false;
        
        LoadRawData(GroundSpeedLength, buffer, offset);
        
        // TODO
    }
}