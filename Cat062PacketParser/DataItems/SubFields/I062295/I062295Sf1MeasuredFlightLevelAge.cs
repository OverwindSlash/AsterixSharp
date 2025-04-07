using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf1MeasuredFlightLevelAge : FixLengthDataItem
{
    public const int MeasuredFlightLevelAgeLength = 1;

    public I062295Sf1MeasuredFlightLevelAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Measured Flight Level Age";
        IsMandatory = false;
        
        LoadRawData(MeasuredFlightLevelAgeLength, buffer, offset);
        
        // TODO
    }
}