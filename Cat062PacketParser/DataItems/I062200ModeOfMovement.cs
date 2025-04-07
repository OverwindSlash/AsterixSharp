using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062200ModeOfMovement : FixLengthDataItem
{
    public enum TransTypes
    {
        ConstantCourse = 0,
        RightTurn = 1,
        LeftTurn = 2,
        Undetermined = 3
    }

    public enum LongTypes
    {
        ConstantGroundspeed = 0,
        IncreasingGroundspeed = 1,
        DecreasingGroundspeed = 2,
        Undetermined = 3
    }

    public enum VertTypes
    {
        Level = 0,
        Climb = 1,
        Descent = 2,
        Undetermined = 3
    }

    public enum AdfTypes
    {
        NoAltitudeDiscrepancy = 0,
        AltitudeDiscrepancy = 1
    }

    public const int ModeOfMovementLength = 1;

    public TransTypes Trans { get; private set; }
    public LongTypes Long { get; private set; }
    public VertTypes Vert { get; private set; }
    public AdfTypes Adf { get; private set; }

    public I062200ModeOfMovement(byte[] buffer, int offset)
    {
        Name = "I062/200, Mode of Movement";
        IsMandatory = false;
        
        LoadRawData(ModeOfMovementLength, buffer, offset);

        Trans = (TransTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 2);
        Long = (LongTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 2, 2);
        Vert = (VertTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 4, 2);
        Adf = (AdfTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 6, 1);
    }
}