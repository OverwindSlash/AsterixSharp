using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf4Mode3AAge : FixLengthDataItem
{
    public const int Mode3AAgeLength = 1;
    public const double LSB = 0.25;

    public double Mda { get; private set; }

    public I062295Sf4Mode3AAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Mode 3/A Age";
        IsMandatory = false;
        
        LoadRawData(Mode3AAgeLength, buffer, offset);

        var mdaValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Mda = mdaValue * LSB;
    }
}