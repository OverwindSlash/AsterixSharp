using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfTrackPositionInCartesianLength = 4;
    public const double LSB = 0.5;

    public double ApcXComponent { get; private set; }
    public double ApcYComponent { get; private set; }


    public I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Track Position (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfTrackPositionInCartesianLength, buffer, offset);

        var xValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        var yValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 16, 16);

        ApcXComponent = xValue * LSB;
        ApcYComponent = yValue * LSB;
    }
}