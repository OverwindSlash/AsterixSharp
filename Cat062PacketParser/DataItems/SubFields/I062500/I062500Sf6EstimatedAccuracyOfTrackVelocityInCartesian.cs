using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackVelocityInCartesianLength = 2;
    public const double LSB = 0.25;

    public double AtvXComponent { get; private set; }
    public double AtvYComponent { get; private set; }

    public I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Velocity (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackVelocityInCartesianLength, buffer, offset);

        var atvXValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        var atvYValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 8);

        AtvXComponent = atvXValue * LSB;
        AtvYComponent = atvYValue * LSB;
    }
}