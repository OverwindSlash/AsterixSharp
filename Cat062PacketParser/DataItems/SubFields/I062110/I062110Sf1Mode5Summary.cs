using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf1Mode5Summary : FixLengthDataItem
{
    public const int Mode5SummaryLength = 1;

    public I062110Sf1Mode5Summary(byte[] buffer, int offset)
    {
        Name = "I062/110, Mode 5 Summary";
        IsMandatory = false;
        
        LoadRawData(Mode5SummaryLength, buffer, offset);
        
        // TODO
    }
}