using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062270TargetSizeOrientation : ExtentableDataItem
{
    public const int MaxTargetSizeOrientationLength = 3;
    public double ORI_LSB = 360 / 128.0;

    public byte Length { get; private set; }
    public bool Fx1 { get; private set; }
    
    public double Orientation { get; private set; }
    public bool Fx2 { get; private set; }
    
    public byte Width { get; private set; }
    public bool Fx3 { get; private set; }

    public I062270TargetSizeOrientation(byte[] buffer, int offset)
    {
        Name = "I062/270, Target Size & Orientation";
        IsMandatory = false;
        
        ParseExtentableData(MaxTargetSizeOrientationLength, buffer, offset);

        Length = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 7);

        if (Fx1)
        {
            var oriValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 8, 7);
            Orientation = oriValue * ORI_LSB;
        }

        if (Fx2)
        {
            Width = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 16, 7);
        }
    }
}