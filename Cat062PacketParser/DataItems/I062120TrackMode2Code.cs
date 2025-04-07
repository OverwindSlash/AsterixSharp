using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062120TrackMode2Code : FixLengthDataItem
{
    public const int TrackMode2CodeLength = 2;

    public bool ReplyA4 { get; private set; }
    public bool ReplyA2 { get; private set; }
    public bool ReplyA1 { get; private set; }

    public bool ReplyB4 { get; private set; }
    public bool ReplyB2 { get; private set; }
    public bool ReplyB1 { get; private set; }

    public bool ReplyC4 { get; private set; }
    public bool ReplyC2 { get; private set; }
    public bool ReplyC1 { get; private set; }

    public bool ReplyD4 { get; private set; }
    public bool ReplyD2 { get; private set; }
    public bool ReplyD1 { get; private set; }

    public I062120TrackMode2Code(byte[] buffer, int offset)
    {
        Name = "I062/120, Track Mode 2 Code";
        IsMandatory = false;
        
        LoadRawData(TrackMode2CodeLength, buffer, offset);

        // BitOperations.GetBit(RawData, 0);   // Spare
        // BitOperations.GetBit(RawData, 1);   // Spare
        // BitOperations.GetBit(RawData, 2);   // Spare
        // BitOperations.GetBit(RawData, 3);   // Spare
        ReplyA4 = BitOperations.GetBit(RawData, 4);
        ReplyA2 = BitOperations.GetBit(RawData, 5);
        ReplyA1 = BitOperations.GetBit(RawData, 6);
        ReplyB4 = BitOperations.GetBit(RawData, 7);
        
        ReplyB2 = BitOperations.GetBit(RawData, 8);
        ReplyB1 = BitOperations.GetBit(RawData, 9);
        ReplyC4 = BitOperations.GetBit(RawData, 10);
        ReplyC2 = BitOperations.GetBit(RawData, 11);
        ReplyC1 = BitOperations.GetBit(RawData, 12);
        ReplyD4 = BitOperations.GetBit(RawData, 13);
        ReplyD2 = BitOperations.GetBit(RawData, 14);
        ReplyD1 = BitOperations.GetBit(RawData, 15);
    }
}