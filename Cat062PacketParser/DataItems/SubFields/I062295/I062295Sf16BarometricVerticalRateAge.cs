using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf16BarometricVerticalRateAge : FixLengthDataItem
{
    public const int BarometricVerticalRateAgeLength = 1;
    public const double LSB = 0.25;

    public double Bvr { get; private set; }

    public I062295Sf16BarometricVerticalRateAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Barometric Vertical Rate Age";
        IsMandatory = false;
        
        LoadRawData(BarometricVerticalRateAgeLength, buffer, offset);

        var bvrValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Bvr = bvrValue * LSB;
    }
}