using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf26IndicatedAirspeed : FixLengthDataItem
{
    public const int IndicatedAirspeedLength = 2;
    public const double LSB = 1;

    public double Ias { get; private set; }

    public I062380Sf26IndicatedAirspeed(byte[] buffer, int offset)
    {
        Name = "I062/380, Indicated Airspeed";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedLength, buffer, offset);

        var iasValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Ias = iasValue * LSB;
    }
}