using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf20TrackAngleAge : FixLengthDataItem
{
    public const int TrackAngleAgeLength = 1;

    public I062295Sf20TrackAngleAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Track Angle Age";
        IsMandatory = false;
        
        LoadRawData(TrackAngleAgeLength, buffer, offset);
        
        // TODO
    }
}