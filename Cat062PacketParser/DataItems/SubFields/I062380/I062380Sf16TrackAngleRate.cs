using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf16TrackAngleRate : FixLengthDataItem
{
    public enum TurnIndicatorTypes
    {
        NotAvailable = 0,
        Left = 1,
        Right = 2,
        Straight = 3
    }

    public const int TrackAngleRateLength = 2;
    public const double ROT_LSB = 0.25;

    public TurnIndicatorTypes TurnIndicator { get; private set; }
    public double RateOfTurn { get; private set; }

    public I062380Sf16TrackAngleRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Track Angle Rate";
        IsMandatory = false;
        
        LoadRawData(TrackAngleRateLength, buffer, offset);

        TurnIndicator = (TurnIndicatorTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 2);
        // BitOperations.GetBit(RawData, 2); // Spare
        // BitOperations.GetBit(RawData, 3); // Spare
        // BitOperations.GetBit(RawData, 4); // Spare
        // BitOperations.GetBit(RawData, 5); // Spare
        // BitOperations.GetBit(RawData, 6); // Spare
        // BitOperations.GetBit(RawData, 7); // Spare
        var rotValue = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 7);
        RateOfTurn = rotValue * ROT_LSB;
        // BitOperations.GetBit(RawData, 15); // Spare
    }
}