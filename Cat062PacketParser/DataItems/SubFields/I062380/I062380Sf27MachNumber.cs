using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf27MachNumber : FixLengthDataItem
{
    public const int MachNumberLength = 2;
    public const double LSB = 0.008;

    public double Mac { get; private set; }

    public I062380Sf27MachNumber(byte[] buffer, int offset)
    {
        Name = "I062/380, Mach Number";
        IsMandatory = false;
        
        LoadRawData(MachNumberLength, buffer, offset);

        var machValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Mac = machValue * LSB;
    }
}