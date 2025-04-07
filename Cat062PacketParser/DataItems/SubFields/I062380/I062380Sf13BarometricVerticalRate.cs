using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf13BarometricVerticalRate : FixLengthDataItem
{
    public const int BarometricVerticalRateLength = 2;

    public I062380Sf13BarometricVerticalRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Vertical Rate";
        IsMandatory = false;
        
        LoadRawData(BarometricVerticalRateLength, buffer, offset);
        
        // TODO
    }
}