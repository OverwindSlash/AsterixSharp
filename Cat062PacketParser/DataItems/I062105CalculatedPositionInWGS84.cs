using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062105CalculatedPositionInWGS84 : FixLengthDataItem
{
    public const int CalculatedPositionInWGS84Length = 8;
    public const double LSB = 180.0 / 33554432;
    
    public double Longitude { get; private set; }
    public double Latitude { get; private set; }
    
    public I062105CalculatedPositionInWGS84(byte[] buffer, int offset)
    {
        Name = "I062/105, Calculated Position In WGS-84 Co-ordinates";
        IsMandatory = false;
        
        LoadRawData(CalculatedPositionInWGS84Length, buffer, offset);

        var latValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 32);
        var lonValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 32, 32);
        
        Latitude = latValue * LSB;
        Longitude = lonValue * LSB;
    }
}   