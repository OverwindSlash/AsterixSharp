using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf20MetData : FixLengthDataItem
{
    public const int MetDataLength = 8;

    public I062380Sf20MetData(byte[] buffer, int offset)
    {
        Name = "I062/380, Met Data";
        IsMandatory = false;
        
        LoadRawData(MetDataLength, buffer, offset);
        
        // TODO
    }
}