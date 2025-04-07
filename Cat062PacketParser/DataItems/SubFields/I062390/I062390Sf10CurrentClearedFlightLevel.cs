using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf10CurrentClearedFlightLevel : FixLengthDataItem
{
    public const int CurrentClearedFlightLevelLength = 2;

    public I062390Sf10CurrentClearedFlightLevel(byte[] buffer, int offset)
    {
        Name = "I062/390, Current Cleared Flight Level";
        IsMandatory = false;
        
        LoadRawData(CurrentClearedFlightLevelLength, buffer, offset);
        
        // TODO
    }
}