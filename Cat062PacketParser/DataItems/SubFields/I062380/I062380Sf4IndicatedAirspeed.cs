using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf4IndicatedAirspeed : FixLengthDataItem
{
    public const int IndicatedAirspeedLength = 2;
    public const double IAS_LSB = 0.00006104;
    public const double MACH_LSB = 0.001;
    
    public bool IsMach { get; private set; }
    public double IasAirspeed { get; private set; }

    public I062380Sf4IndicatedAirspeed(byte[] buffer, int offset)
    {
        Name = "I062/380, Indicated Airspeed / Mach No";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedLength, buffer, offset);

        IsMach = BitOperations.GetBit(RawData, 0);

        var airspeed = BitOperations.ConvertBitsBigEndianSigned(RawData, 1, 15);
        
        IasAirspeed = IsMach ? airspeed * MACH_LSB : airspeed * IAS_LSB;
    }
}