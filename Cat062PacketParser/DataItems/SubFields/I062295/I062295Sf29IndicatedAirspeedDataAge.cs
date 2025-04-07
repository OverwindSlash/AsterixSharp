using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf29IndicatedAirspeedDataAge : FixLengthDataItem
{
    public const int IndicatedAirspeedDataAgeLength = 1;
    public const double LSB = 0.25;

    public double Iar { get; private set; }

    public I062295Sf29IndicatedAirspeedDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Indicated Airspeed Data Age";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedDataAgeLength, buffer, offset);

        var iarValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Iar = iarValue * LSB;
    }
}