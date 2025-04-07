using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf8TrajectoryIntentStatus : FixLengthDataItem
{
    public const int TrajectoryIntentStatusLength = 1;
    
    public bool IsTrajectoryIntentDataAvailable { get; private set; }
    public bool IsTrajectoryIntentDataValid { get; private set; }
    public bool Fx { get; private set; }

    public I062380Sf8TrajectoryIntentStatus(byte[] buffer, int offset)
    {
        Name = "I062/380, Trajectory Intent Status";
        IsMandatory = false;
        
        LoadRawData(TrajectoryIntentStatusLength, buffer, offset);

        IsTrajectoryIntentDataAvailable = BitOperations.GetBit(RawData, 0);
        IsTrajectoryIntentDataValid = BitOperations.GetBit(RawData, 1);
        Fx = BitOperations.GetBit(RawData, 7);
    }
}