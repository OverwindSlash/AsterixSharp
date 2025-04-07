using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf26GeometricAltitudeAge : FixLengthDataItem
{
    public const int GeometricAltitudeAgeLength = 1;
    public const double LSB = 0.25;

    public double Gal { get; private set; }

    public I062295Sf26GeometricAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Geometric Altitude Age";
        IsMandatory = false;
        
        LoadRawData(GeometricAltitudeAgeLength, buffer, offset);

        var galValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Gal = galValue * LSB;
    }
}