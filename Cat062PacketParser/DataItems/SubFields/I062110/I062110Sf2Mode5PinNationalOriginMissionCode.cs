using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf2Mode5PinNationalOriginMissionCode : FixLengthDataItem
{
    public const int Mode5PinNationalOriginMissionCodeLength = 4;

    public I062110Sf2Mode5PinNationalOriginMissionCode(byte[] buffer, int offset)
    {
        Name = "I062/110, Mode 5 PIN / National Origin / Mission Code";
        IsMandatory = false;
        
        LoadRawData(Mode5PinNationalOriginMissionCodeLength, buffer, offset);
        
        // TODO
    }
}