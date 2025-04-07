using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf3Mode5ReportedPosition : FixLengthDataItem
{
    public const int Mode5ReportedPositionLength = 6;

    public I062110Sf3Mode5ReportedPosition(byte[] buffer, int offset)
    {
        Name = "I062/110, Mode 5 Reported Position";
        IsMandatory = false;
        
        LoadRawData(Mode5ReportedPositionLength, buffer, offset);
        
        // TODO
    }
}