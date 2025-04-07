using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf5ExtendedMode1CodeInOctalRepresentation : FixLengthDataItem
{
    public const int ExtendedMode1CodeInOctalRepresentationLength = 2;

    public I062110Sf5ExtendedMode1CodeInOctalRepresentation(byte[] buffer, int offset)
    {
        Name = "I062/110, Extended Mode 1 Code in Octal Representation";
        IsMandatory = false;
        
        LoadRawData(ExtendedMode1CodeInOctalRepresentationLength, buffer, offset);
        
        // TODO
    }
}