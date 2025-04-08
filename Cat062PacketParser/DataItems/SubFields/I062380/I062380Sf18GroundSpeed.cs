using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf18GroundSpeed : FixLengthDataItem
{
    public const int GroundSpeedLength = 2;
    public const double LSB = 0.00006103515625;

    public double Gsp { get; private set; }

    public I062380Sf18GroundSpeed(byte[] buffer, int offset)
    {
        Name = "I062/380, Ground Speed";
        IsMandatory = false;
        
        LoadRawData(GroundSpeedLength, buffer, offset);

        var gspValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Gsp = gspValue * LSB;
    }
}