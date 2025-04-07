using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf8EstimatedAccuracyOfRateOfClimbDescent : FixLengthDataItem
{
    public const int EstimatedAccuracyOfRateOfClimbDescentLength = 1;
    public const double LSB = 6.25;

    public double Arc { get; private set; }

    public I062500Sf8EstimatedAccuracyOfRateOfClimbDescent(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracy Of Rate Of Climb/Descent";
        IsMandatory = false;
        
        LoadRawData(EstimatedAccuracyOfRateOfClimbDescentLength, buffer, offset);

        var arcValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Arc = arcValue * LSB;
    }
}