using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf7EstimatedAccuracyOfAccelerationInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfAccelerationInCartesianLength = 2;
    public const double LSB = 0.25;

    public double AaXComponent { get; private set; }
    public double AaYComponent { get; private set; }

    public I062500Sf7EstimatedAccuracyOfAccelerationInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Acceleration (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfAccelerationInCartesianLength, buffer, offset);

        var xValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        var yValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 8);

        AaXComponent = xValue * LSB;
        AaYComponent = yValue * LSB;
    }
}