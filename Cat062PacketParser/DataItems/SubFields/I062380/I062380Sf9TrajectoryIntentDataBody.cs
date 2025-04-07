using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf9TrajectoryIntentDataBody : FixLengthDataItem
{
    public int TrajectoryIntentDataBodyLength = 15;

    public I062380Sf9TrajectoryIntentDataBody(byte[] buffer, int offset)
    {
        Name = "I062/380, Trajectory Intent Data Body";
        IsMandatory = false;
        
        LoadRawData(TrajectoryIntentDataBodyLength, buffer, offset);
    }
}