using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf7EstimatedAccuracyOfAccelerationInCartesian : FixLengthDataItem
{
    public const int EstimatedAccuracyOfAccelerationInCartesianLength = 2;

    public I062500Sf7EstimatedAccuracyOfAccelerationInCartesian(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Acceleration (Cartesian)";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfAccelerationInCartesianLength, buffer, offset);
        
        // todo
    }
}