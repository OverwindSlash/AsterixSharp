using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062100CalculatedTrackPositionInCartesian : FixLengthDataItem
{
    public const int CalculatedTrackPositionInCartesianLength = 6;
    public const double LSB = 0.5;
    
    public double X { get; set; }
    public double Y { get; set; }
    
    public I062100CalculatedTrackPositionInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/100, Calculated Track Position. (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(CalculatedTrackPositionInCartesianLength, buffer, offset);
        
        var xValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 24);
        var yValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 24, 24);

        X = xValue * LSB;
        Y = yValue * LSB;
    }
}