using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf27PositionUncertaintyAge : FixLengthDataItem
{
    public const int PositionUncertaintyAgeLength = 1;
    public const double LSB = 0.25;

    public double Pun { get; private set; }

    public I062295Sf27PositionUncertaintyAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Position Uncertainty Age";
        IsMandatory = false;
        
        LoadRawData(PositionUncertaintyAgeLength, buffer, offset);

        var punValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Pun = punValue * LSB;
    }
}