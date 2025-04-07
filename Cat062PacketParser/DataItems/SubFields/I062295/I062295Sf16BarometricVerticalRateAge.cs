using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf16BarometricVerticalRateAge : FixLengthDataItem
{
    public const int BarometricVerticalRateAgeLength = 1;

    public I062295Sf16BarometricVerticalRateAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Barometric Vertical Rate Age";
        IsMandatory = false;
        
        LoadRawData(BarometricVerticalRateAgeLength, buffer, offset);
        
        // TODO
    }
}