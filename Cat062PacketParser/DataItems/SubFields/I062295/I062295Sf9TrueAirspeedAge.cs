using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf9TrueAirspeedAge : FixLengthDataItem
{
    public const int TrueAirspeedAgeLength = 1;
    public const double LSB = 0.25;

    public double Tas { get; private set; }

    public I062295Sf9TrueAirspeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, True Airspeed Age";
        IsMandatory = false;
        
        LoadRawData(TrueAirspeedAgeLength, buffer, offset);

        var tasValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Tas = tasValue * LSB;
    }
}