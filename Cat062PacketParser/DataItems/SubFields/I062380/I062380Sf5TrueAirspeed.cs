using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf5TrueAirspeed :FixLengthDataItem
{
    public const int IndicatedAirspeedLength = 2;
    
    public ushort TrueAirSpeed { get; private set; }
    
    public I062380Sf5TrueAirspeed(byte[] buffer, int offset)
    {
        Name = "I062/380, True Airspeed";
        IsMandatory = false;
        
        LoadRawData(IndicatedAirspeedLength, buffer, offset);
        
        TrueAirSpeed = (ushort)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
    }
}