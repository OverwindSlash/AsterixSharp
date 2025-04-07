using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf8IndicatedAirspeedAge : FixLengthDataItem
{
    public const int IndicatedAirspeedAgeLength = 1;
    public const double LSB = 0.25;

    public double Ias { get; private set; }

    public I062295Sf8IndicatedAirspeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Indicated Airspeed Age";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedAgeLength, buffer, offset);

        var iasValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Ias = iasValue * LSB;
    }
}