using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf28BarometricPressureSetting : FixLengthDataItem
{
    public const int BarometricPressureSettingLength = 2;

    public I062380Sf28BarometricPressureSetting(byte[] buffer, int offset)
    {
        Name = "I062/380, Barometric Pressure Setting";
        IsMandatory = false;
        
        LoadRawData(BarometricPressureSettingLength, buffer, offset);
        
        // TODO
    }
}