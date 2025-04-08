using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf14GeometricVerticalRate : FixLengthDataItem
{
    public const int GeometricVerticalRateLength = 2;
    public const double LSB = 6.25;

    public double Gvr { get; private set; }

    public I062380Sf14GeometricVerticalRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Vertical Rate";
        IsMandatory = false;
        
        LoadRawData(GeometricVerticalRateLength, buffer, offset);

        var gvrValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        Gvr = gvrValue * LSB;
    }
}