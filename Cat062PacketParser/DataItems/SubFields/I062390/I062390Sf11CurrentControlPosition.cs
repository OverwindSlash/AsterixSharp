using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf11CurrentControlPosition : FixLengthDataItem
{
    public const int CurrentControlPositionLength = 2;

    public I062390Sf11CurrentControlPosition(byte[] buffer, int offset)
    {
        Name = "I062/390, Current Control Position";
        IsMandatory = false;
        
        LoadRawData(CurrentControlPositionLength, buffer, offset);
        
        // TODO
    }
}