using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf28BarometricPressureSetting : FixLengthDataItem
{
    public const int BarometricPressureSettingLength = 2;
    public const double LSB = 0.1;

    public double Bps { get; private set; }

    public I062380Sf28BarometricPressureSetting(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Pressure Setting";
        IsMandatory = false;
        
        LoadRawData(BarometricPressureSettingLength, buffer, offset);

        var bpsValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Bps = bpsValue * LSB;
    }
}