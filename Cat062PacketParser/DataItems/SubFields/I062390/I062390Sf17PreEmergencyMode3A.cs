using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf17PreEmergencyMode3A : FixLengthDataItem
{
    public const int PreEmergencyMode3ALength = 2;

    public I062390Sf17PreEmergencyMode3A(byte[] buffer, int offset)
    {
        Name = "I062/390, Pre-Emergency Mode 3/A";
        IsMandatory = false;
        
        LoadRawData(PreEmergencyMode3ALength, buffer, offset);
        
        // TODO
    }
}