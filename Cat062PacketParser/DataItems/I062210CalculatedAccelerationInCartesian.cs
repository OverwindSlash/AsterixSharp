using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062210CalculatedAccelerationInCartesian : FixLengthDataItem
{
    public const int CalculatedAccelerationInCartesianLength = 2;
    public const double LSB = 0.25;
    
    public double Ax { get; set; }
    public double Ay { get; set; }
    
    public I062210CalculatedAccelerationInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/210, Calculated Acceleration (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(CalculatedAccelerationInCartesianLength, buffer, offset);
        
        Ax = RawData[0] * LSB;
        Ay = RawData[1] * LSB;
    }
}