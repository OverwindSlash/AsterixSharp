using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062220CalculatedRateOfClimbDescent : FixLengthDataItem
{
    public const int CalculatedRateOfClimbDescentLength = 2;
    public const double LSB = 6.25;

    public double RateOfClimbDescent { get; private set; }

    public I062220CalculatedRateOfClimbDescent(byte[] buffer, int offset)
    {
        Name = "I062/220, Calculated Rate Of Climb/Descent";
        IsMandatory = false;
        
        LoadRawData(CalculatedRateOfClimbDescentLength, buffer, offset);

        var rocdValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        RateOfClimbDescent = rocdValue * LSB;
    }
}