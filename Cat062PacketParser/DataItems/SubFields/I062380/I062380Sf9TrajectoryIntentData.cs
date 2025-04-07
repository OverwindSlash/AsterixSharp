using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf9TrajectoryIntentData : RepeatableDataItem
{
    public const int TrajectoryIntentDataRepeatCountLength = 1;
    
    public List<I062380Sf9TrajectoryIntentDataBody> TrajectoryIntentDataItems = new();
    
    public I062380Sf9TrajectoryIntentData(byte[] buffer, int offset)
    {
        Name = "I062/380, Trajectory Intent Data";
        IsMandatory = false;
        
        LoadRepeatCountItem(TrajectoryIntentDataRepeatCountLength, buffer, offset);
        offset += TrajectoryIntentDataRepeatCountLength;

        for (int i = 0; i < RepeatCount; i++)
        {
            var body = new I062380Sf9TrajectoryIntentDataBody(buffer, offset);
            TrajectoryIntentDataItems.Add(body);
            offset += body.Length;
        }
    }
}