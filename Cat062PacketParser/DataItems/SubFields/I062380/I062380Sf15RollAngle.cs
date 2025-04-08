using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf15RollAngle : FixLengthDataItem
{
    public const int RollAngleLength = 2;
    public const double LSB = 0.01;

    public double Ran { get; private set; }

    public I062380Sf15RollAngle(byte[] buffer, int offset)
    {
        Name = "I062/380, Roll Angle";
        IsMandatory = false;
        
        LoadRawData(RollAngleLength, buffer, offset);

        var ranValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        Ran = ranValue * LSB;
    }
}