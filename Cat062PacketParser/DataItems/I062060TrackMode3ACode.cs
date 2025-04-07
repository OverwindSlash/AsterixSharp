using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062060TrackMode3ACode : FixLengthDataItem
{
    public const int TrackMode3ACodeLength = 2;
    
    public bool IsCodeNotValidated { get; set; }
    public bool IsGarbledCode { get; set; }
    public bool HasChanged { get; set; }

    public bool ReplyA4 { get; set; }
    public bool ReplyA2 { get; set; }
    public bool ReplyA1 { get; set; }

    public bool ReplyB4 { get; set; }
    public bool ReplyB2 { get; set; }
    public bool ReplyB1 { get; set; }

    public bool ReplyC4 { get; set; }
    public bool ReplyC2 { get; set; }
    public bool ReplyC1 { get; set; }

    public bool ReplyD4 { get; set; }
    public bool ReplyD2 { get; set; }
    public bool ReplyD1 { get; set; }
    
    public I062060TrackMode3ACode(byte[] buffer, int offset)
    {
        Name = "I062/060, Track Mode 3/A Code";
        IsMandatory = false;
        
        LoadRawData(TrackMode3ACodeLength, buffer, offset);
        
        IsCodeNotValidated = BitOperations.GetBit(RawData, 0);
        IsGarbledCode = BitOperations.GetBit(RawData, 1);
        HasChanged = BitOperations.GetBit(RawData, 2);
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