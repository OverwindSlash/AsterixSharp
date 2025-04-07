using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062135CalculatedTrackBarometricAltitude : FixLengthDataItem
{
    public const int CalculatedTrackBarometricAltitudeLength = 2;
    public const double LSB = 0.25;

    public bool IsQnhCorrectionApplied { get; private set; }
    public double CalculatedTrackBarometricAltitude { get; private set; }

    public I062135CalculatedTrackBarometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/135, Calculated Track Barometric Altitude";
        IsMandatory = false;
        
        LoadRawData(CalculatedTrackBarometricAltitudeLength, buffer, offset);

        IsQnhCorrectionApplied = BitOperations.GetBit(RawData, 0);
        var altitudeValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 1, 15);
        CalculatedTrackBarometricAltitude = altitudeValue * LSB;
    }
}