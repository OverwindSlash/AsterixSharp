using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf23MeteorologicalDataAge : FixLengthDataItem
{
    public const int MeteorologicalAgeLength = 1;
    public const double LSB = 0.25;

    public double Met { get; private set; }

    public I062295Sf23MeteorologicalDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Meteorological Data Age";
        IsMandatory = false;
        
        LoadRawData(MeteorologicalAgeLength, buffer, offset);

        var metValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Met = metValue * LSB;
    }
}