using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf7VdlAge : FixLengthDataItem
{
    public const int VdlAgeLength = 1;
    public const double LSB = 0.25;

    public double Vdl { get; private set; }

    public I062290Sf7VdlAge(byte[] buffer, int offset)
    {
        Name = "I062/290, VDL Age";
        IsMandatory = false;
        
        LoadRawData(VdlAgeLength, buffer, offset);
        
        var vdlValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Vdl = vdlValue * LSB;
    }
}