using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf2MeasuredPosition : FixLengthDataItem
{
    public const int MeasuredPositionLength = 4;
    public const double RHO_LSB = 1 / 256.0;
    public const double THETA_LSB = 360 / 65536.0;
    
    public double Rho { get; private set; }
    public double Theta { get; private set; }

    public I062340Sf2MeasuredPosition(byte[] buffer, int offset)
    {
        Name = "I062/340, Measured Position";
        IsMandatory = false;
        
        LoadRawData(MeasuredPositionLength, buffer, offset);

        var rhoValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Rho = rhoValue * RHO_LSB;

        var thetaValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 16, 16);
        Theta = thetaValue * THETA_LSB;
    }
}