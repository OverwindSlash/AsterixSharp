using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062040TrackNumber : FixLengthDataItem
{
    public const int TrackNumberLength = 2;
    
    public ushort TrackNumber { get; private set; }

    public I062040TrackNumber(byte[] buffer, int offset)
    {
        Name = "I062/040, Track Number";
        IsMandatory = true;
        
        LoadRawData(TrackNumberLength, buffer, offset);
        
        TrackNumber = (ushort)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
    }
}