using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf3IfpsFlightId : FixLengthDataItem
{
    public const int IfpsFlightIdLength = 4;

    public I062390Sf3IfpsFlightId(byte[] buffer, int offset)
    {
        Name = "I062/390, IFPS Flight ID";
        IsMandatory = false;
        
        LoadRawData(IfpsFlightIdLength, buffer, offset);
        
        // TODO
    }
}