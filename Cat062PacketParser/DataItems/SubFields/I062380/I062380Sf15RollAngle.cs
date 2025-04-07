using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf15RollAngle : FixLengthDataItem
{
    public const int RollAngleLength = 2;

    public I062380Sf15RollAngle(byte[] buffer, int offset)
    {
        Name = "I062/380, Roll Angle";
        IsMandatory = false;
        
        LoadRawData(RollAngleLength, buffer, offset);
        
        // TODO
    }
}