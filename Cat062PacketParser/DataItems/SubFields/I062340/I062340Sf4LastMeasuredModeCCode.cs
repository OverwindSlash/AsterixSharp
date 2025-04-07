using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf4LastMeasuredModeCCode : FixLengthDataItem
{
    public const int LastMeasuredModeCCodeLength = 2;
    public const double LSB = 0.25;

    public bool IsCodeNotValidated { get; private set; }
    public bool IsGarbledCode { get; private set; }
    public double Mdc { get; private set; }

    public I062340Sf4LastMeasuredModeCCode(byte[] buffer, int offset)
    {
        Name = "I062/340, Last Measured Mode C Code";
        IsMandatory = false;
        
        LoadRawData(LastMeasuredModeCCodeLength, buffer, offset);

        IsCodeNotValidated = BitOperations.GetBit(RawData, 0);
        IsGarbledCode = BitOperations.GetBit(RawData, 1);
        var mdcValue = (short)BitOperations.ConvertBitsBigEndianSigned(RawData, 2, 14);
        Mdc = mdcValue * LSB;
    }
}