using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf2PsrAge : FixLengthDataItem
{
    public const int PsrAgeLength = 1;
    public const double LSB = 0.25;

    public double Psr { get; private set; }

    public I062290Sf2PsrAge(byte[] buffer, int offset)
    {
        Name = "I062/290, PSR Age";
        IsMandatory = false;
        
        LoadRawData(PsrAgeLength, buffer, offset);

        var psrValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Psr = psrValue * LSB;
    }
}