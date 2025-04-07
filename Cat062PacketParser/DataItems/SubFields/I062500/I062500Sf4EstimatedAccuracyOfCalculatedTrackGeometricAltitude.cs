using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude : FixLengthDataItem
{
    public const int EstimatedAccuracyOfCalculatedTrackGeometricAltitudeLength = 1;
    public const double LSB = 6.25;

    public double Aga { get; private set; }

    public I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Calculated Track Geometric Altitude";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfCalculatedTrackGeometricAltitudeLength, buffer, offset);

        var altitudeValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Aga = altitudeValue * LSB;
    }
}