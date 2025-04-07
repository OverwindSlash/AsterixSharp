using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf14GeometricVerticalRate : FixLengthDataItem
{
    public const int BarometricVerticalRateLength = 2;

    public I062380Sf14GeometricVerticalRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Vertical Rate";
        IsMandatory = false;
        
        LoadRawData(BarometricVerticalRateLength, buffer, offset);
        
        // TODO
    }
}