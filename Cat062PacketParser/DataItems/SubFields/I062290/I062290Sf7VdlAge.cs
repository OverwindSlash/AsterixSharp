using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf7VdlAge : FixLengthDataItem
{
    public const int VdlAgeLength = 1;

    public I062290Sf7VdlAge(byte[] buffer, int offset)
    {
        Name = "I062/290, VDL Age";
        IsMandatory = false;
        
        LoadRawData(VdlAgeLength, buffer, offset);
        
        // TODO
    }
}