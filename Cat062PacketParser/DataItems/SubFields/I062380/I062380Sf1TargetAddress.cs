using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf1TargetAddress : FixLengthDataItem
{
    public const int TargetAddressLength = 3;
    
    public int TargetAddress { get; private set; }

    public I062380Sf1TargetAddress(byte[] buffer, int offset)
    {
        Name = "I062/380, Target Address";
        IsMandatory = false;
        
        LoadRawData(TargetAddressLength, buffer, offset);

        var addrValue = (int)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 24);
        TargetAddress = addrValue;
    }
}