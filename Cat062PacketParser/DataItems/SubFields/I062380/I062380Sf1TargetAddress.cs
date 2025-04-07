using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf1TargetAddress : FixLengthDataItem
{
    public const int TargetAddressLength = 3;

    public I062380Sf1TargetAddress(byte[] buffer, int offset)
    {
        Name = "I062/380, Target Address";
        IsMandatory = false;
        
        LoadRawData(TargetAddressLength, buffer, offset);
    }
}