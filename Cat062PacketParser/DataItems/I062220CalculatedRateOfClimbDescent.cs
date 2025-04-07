using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062220CalculatedRateOfClimbDescent : FixLengthDataItem
{
    public const int CalculatedRateOfClimbDescentLength = 2;

    public I062220CalculatedRateOfClimbDescent(byte[] buffer, int offset)
    {
        Name = "I062/220, Calculated Rate Of Climb/Descent";
        IsMandatory = false;
        
        LoadRawData(CalculatedRateOfClimbDescentLength, buffer, offset);
        
        // TODO
    }
}