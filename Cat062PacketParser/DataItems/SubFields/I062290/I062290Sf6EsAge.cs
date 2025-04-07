using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf6EsAge : FixLengthDataItem
{
    public const int EsAgeLength = 1;
    public const double LSB = 0.25;

    public double Es { get; private set; }

    public I062290Sf6EsAge(byte[] buffer, int offset)
    {
        Name = "I062/290, ES Age";
        IsMandatory = false;
        
        LoadRawData(EsAgeLength, buffer, offset);

        var esValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Es = esValue * LSB;
    }
}