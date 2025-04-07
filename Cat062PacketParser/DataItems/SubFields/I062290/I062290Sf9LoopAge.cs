using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf9LoopAge : FixLengthDataItem
{
    public const int LoopAgeLength = 1;
    public const double LSB = 0.25;

    public double Lop { get; private set; }

    public I062290Sf9LoopAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Loop Age";
        IsMandatory = false;
        
        LoadRawData(LoopAgeLength, buffer, offset);

        var lopValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Lop = lopValue * LSB;
    }
}