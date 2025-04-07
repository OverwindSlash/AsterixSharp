using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf3SsrAge : FixLengthDataItem
{
    public const int SsrAgeLength = 1;
    public const double LSB = 0.25;

    public double Ssr { get; private set; }
    
    public I062290Sf3SsrAge(byte[] buffer, int offset)
    {
        Name = "I062/290, SSR Age";
        IsMandatory = false;
        
        LoadRawData(SsrAgeLength, buffer, offset);

        var ssrValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Ssr = ssrValue * LSB;
    }
}