using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf25PositionAge : FixLengthDataItem
{
    public const int PositionAgeLength = 1;
    public const double LSB = 0.25;

    public double Pos { get; private set; }

    public I062295Sf25PositionAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Position Age";
        IsMandatory = false;
        
        LoadRawData(PositionAgeLength, buffer, offset);

        var posValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Pos = posValue * LSB;
    }
}