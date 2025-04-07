using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf5EstimatedAccuracyOfCalculatedTrackBarometricAltitude : FixLengthDataItem
{
    public const int EstimatedAccuracyOfCalculatedTrackBarometricAltitudeLength = 1;
    public const double LSB = 0.25;

    public double Aba { get; private set; }

    public I062500Sf5EstimatedAccuracyOfCalculatedTrackBarometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Calculated Track Barometric Altitude";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfCalculatedTrackBarometricAltitudeLength, buffer, offset);

        var altitudeValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Aba = altitudeValue * LSB;
    }
}