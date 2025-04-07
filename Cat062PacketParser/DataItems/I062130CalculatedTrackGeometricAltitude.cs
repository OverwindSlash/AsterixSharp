using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062130CalculatedTrackGeometricAltitude : FixLengthDataItem
{
    public const int CalculatedTrackGeometricAltitudeLength = 2;
    public const double LSB = 6.25;
    
    public double CalculatedTrackGeometricAltitude { get; private set; }
    public I062130CalculatedTrackGeometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/130, Calculated Track Geometric Altitude";
        IsMandatory = false;
        
        LoadRawData(CalculatedTrackGeometricAltitudeLength, buffer, offset);

        var altitudeValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        CalculatedTrackGeometricAltitude = altitudeValue * LSB;
    }
}