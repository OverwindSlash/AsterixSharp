using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062185CalculatedTrackVelocityInCartesian : FixLengthDataItem
{
    public const int CalculatedTrackVelocityInCartesianLength = 4;
    public const double LSB = 0.25;
    
    public double Vx { get; set; }
    public double Vy { get; set; }
    
    public I062185CalculatedTrackVelocityInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/185, Calculated Track Velocity (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(CalculatedTrackVelocityInCartesianLength, buffer, offset);
        
        var vxValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        var vyValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 16, 16);

        Vx = vxValue * LSB;
        Vy = vyValue * LSB;
    }
}