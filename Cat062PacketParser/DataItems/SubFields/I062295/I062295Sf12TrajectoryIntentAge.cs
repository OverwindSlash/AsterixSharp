using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf12TrajectoryIntentAge : FixLengthDataItem
{
    public const int TrajectoryIntentAgeLength = 1;

    public I062295Sf12TrajectoryIntentAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Trajectory Intent Age";
        IsMandatory = false;
        
        LoadRawData(TrajectoryIntentAgeLength, buffer, offset);
        
        // TODO
    }
}