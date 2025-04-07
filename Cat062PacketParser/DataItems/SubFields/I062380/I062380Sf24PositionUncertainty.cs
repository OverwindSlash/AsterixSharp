using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf24PositionUncertainty : FixLengthDataItem
{
    public const int PositionUncertaintyLength = 1;

    public I062380Sf24PositionUncertainty(byte[] buffer, int offset)
    {
        Name = "I062/380, Position Uncertainty";
        IsMandatory = false;
        
        LoadRawData(PositionUncertaintyLength, buffer, offset);
        
        // TODO
    }
}