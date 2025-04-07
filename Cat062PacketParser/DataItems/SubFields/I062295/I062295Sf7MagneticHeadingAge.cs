using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062295Sf7MagneticHeadingAge : FixLengthDataItem
{
    public const int MagneticHeadingAgeLength = 1;

    public I062295Sf7MagneticHeadingAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Magnetic Heading Age";
        IsMandatory = false;
        
        LoadRawData(MagneticHeadingAgeLength, buffer, offset);
        
        // TODO
    }
}