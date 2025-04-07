using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf31BarometricPressureSettingDataAge : FixLengthDataItem
{
    public const int BarometricPressureSettingDataAgeLength = 1;

    public I062295Sf31BarometricPressureSettingDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Barometric Pressure Setting Data Age";
        IsMandatory = false;
        
        LoadRawData(BarometricPressureSettingDataAgeLength, buffer, offset);
        
        // TODO
    }
}