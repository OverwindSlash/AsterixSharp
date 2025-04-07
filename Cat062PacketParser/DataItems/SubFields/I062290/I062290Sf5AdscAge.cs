using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf5AdscAge : FixLengthDataItem
{
    public const int AdscAgeLength = 2;
    public const double LSB = 0.25;

    public double Ads { get; private set; }

    public I062290Sf5AdscAge(byte[] buffer, int offset)
    {
        Name = "I062/290, ADS-C Age";
        IsMandatory = false;
        
        LoadRawData(AdscAgeLength, buffer, offset);

        var adsValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Ads = adsValue * LSB;
    }
}