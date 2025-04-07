using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf17TrackAngle : FixLengthDataItem
{
    public const int TrackAngleLength = 2;

    public I062380Sf17TrackAngle(byte[] buffer, int offset)
    {
        Name = "I062/380, Track Angle";
        IsMandatory = false;
        
        LoadRawData(TrackAngleLength, buffer, offset);
        
        // TODO
    }
}