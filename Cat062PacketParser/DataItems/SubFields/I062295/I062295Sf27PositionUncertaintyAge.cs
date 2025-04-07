using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf27PositionUncertaintyAge : FixLengthDataItem
{
    public const int PositionUncertaintyAgeLength = 1;

    public I062295Sf27PositionUncertaintyAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Position Uncertainty Age";
        IsMandatory = false;
        
        LoadRawData(PositionUncertaintyAgeLength, buffer, offset);
        
        // TODO
    }
}