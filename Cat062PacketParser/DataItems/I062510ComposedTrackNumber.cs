using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062510ComposedTrackNumber : ExtentableDataItem
{
    public const int MaxComposedTrackNumberLength = 6;

    public byte SystemUnitIdentification { get; private set; }
    public short SystemTrackNumber { get; private set; }
    public bool Fx { get; private set; }

    public I062510ComposedTrackNumber(byte[] buffer, int offset)
    {
        Name = "I062/510, Composed Track Number";
        IsMandatory = false;
        
        ParseExtentableData(MaxComposedTrackNumberLength, buffer, offset);

        SystemUnitIdentification = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        SystemTrackNumber = (short)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 15);
        Fx = BitOperations.GetBit(RawData, 23);
    }
}