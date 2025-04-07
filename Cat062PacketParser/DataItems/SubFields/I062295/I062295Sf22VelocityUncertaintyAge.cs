using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf22VelocityUncertaintyAge : FixLengthDataItem
{
    public const int VelocityUncertaintyAgeLength = 1;

    public I062295Sf22VelocityUncertaintyAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Velocity Uncertainty Age";
        IsMandatory = false;
        
        LoadRawData(VelocityUncertaintyAgeLength, buffer, offset);
        
        //TODO
    }
}