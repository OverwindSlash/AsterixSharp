using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf18RollAngleAge : FixLengthDataItem
{
    public const int RollAngleAgeLength = 1;

    public I062295Sf18RollAngleAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Roll Angle Age";
        IsMandatory = false;
        
        LoadRawData(RollAngleAgeLength, buffer, offset);
        
        // TODO
    }
}