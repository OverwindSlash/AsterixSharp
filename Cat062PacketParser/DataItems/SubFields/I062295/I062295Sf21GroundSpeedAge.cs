using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf21GroundSpeedAge : FixLengthDataItem
{
    public const int GroundSpeedAgeLength = 1;
    public const double LSB = 0.25;

    public double Gsp { get; private set; }

    public I062295Sf21GroundSpeedAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Ground Speed Age";
        IsMandatory = false;
        
        LoadRawData(GroundSpeedAgeLength, buffer, offset);

        var gspValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Gsp = gspValue * LSB;
    }
}