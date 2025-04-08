using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf13BarometricVerticalRate : FixLengthDataItem
{
    public const int BarometricVerticalRateLength = 2;
    public const double LSB = 6.25;

    public double Bvr { get; private set; }

    public I062380Sf13BarometricVerticalRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Vertical Rate";
        IsMandatory = false;
        
        LoadRawData(BarometricVerticalRateLength, buffer, offset);

        var bvrValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        Bvr = bvrValue * LSB;
    }
}