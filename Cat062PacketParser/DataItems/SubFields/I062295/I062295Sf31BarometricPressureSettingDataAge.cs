using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf31BarometricPressureSettingDataAge : FixLengthDataItem
{
    public const int BarometricPressureSettingDataAgeLength = 1;
    public const double LSB = 0.25;

    public double Bps { get; private set; }

    public I062295Sf31BarometricPressureSettingDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Barometric Pressure Setting Data Age";
        IsMandatory = false;
        
        LoadRawData(BarometricPressureSettingDataAgeLength, buffer, offset);

        var bpsValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Bps = bpsValue * LSB;
    }
}