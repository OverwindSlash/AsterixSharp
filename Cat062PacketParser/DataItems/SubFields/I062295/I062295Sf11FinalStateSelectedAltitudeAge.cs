using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf11FinalStateSelectedAltitudeAge : FixLengthDataItem
{
    public const int FinalStateSelectedAltitudeAgeLength = 1;
    public const double LSB = 0.25;

    public double Fss { get; private set; }

    public I062295Sf11FinalStateSelectedAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Final State Selected Altitude Age";
        IsMandatory = false;
        
        LoadRawData(FinalStateSelectedAltitudeAgeLength, buffer, offset);

        var fssValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Fss = fssValue * LSB;
    }
}