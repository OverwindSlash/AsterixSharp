using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf1FppsIdentificationTag : FixLengthDataItem
{
    public const int FppsIdentificationTagLength = 2;

    public I062390Sf1FppsIdentificationTag(byte[] buffer, int offset)
    {
        Name = "I062/390, FPPS Identification Tag";
        IsMandatory = false;
        
        LoadRawData(FppsIdentificationTagLength, buffer, offset);
        
        // TODO
    }
}