using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf22VelocityUncertaintyAge : FixLengthDataItem
{
    public const int VelocityUncertaintyAgeLength = 1;
    public const double LSB = 0.25;

    public double Vun { get; private set; }

    public I062295Sf22VelocityUncertaintyAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Velocity Uncertainty Age";
        IsMandatory = false;
        
        LoadRawData(VelocityUncertaintyAgeLength, buffer, offset);

        var vunValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Vun = vunValue * LSB;
    }
}