using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf19VelocityUncertainty : FixLengthDataItem
{
    public const int VelocityUncertaintyLength = 1;

    public I062380Sf19VelocityUncertainty(byte[] buffer, int offset)
    {
        Name = "I062/380, Velocity Uncertainty";
        IsMandatory = false;
        
        LoadRawData(VelocityUncertaintyLength, buffer, offset);
        
        // TODO
    }
}