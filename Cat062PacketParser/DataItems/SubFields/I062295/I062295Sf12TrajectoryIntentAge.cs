using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf12TrajectoryIntentAge : FixLengthDataItem
{
    public const int TrajectoryIntentAgeLength = 1;
    public const double LSB = 0.25;

    public double Tid { get; private set; }

    public I062295Sf12TrajectoryIntentAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Trajectory Intent Age";
        IsMandatory = false;
        
        LoadRawData(TrajectoryIntentAgeLength, buffer, offset);

        var tidValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Tid = tidValue * LSB;
    }
}