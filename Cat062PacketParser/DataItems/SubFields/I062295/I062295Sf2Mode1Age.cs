using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf2Mode1Age : FixLengthDataItem
{
    public const int Mode1AgeLength = 1;

    public I062295Sf2Mode1Age(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 1 Age";
        IsMandatory = false;
        
        LoadRawData(Mode1AgeLength, buffer, offset);
        
        // TODO
    }
}