using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf16TrackAngleRate : FixLengthDataItem
{
    public const int TrackAngleRateLength = 2;

    public I062380Sf16TrackAngleRate(byte[] buffer, int offset)
    {
        Name = "I062/380, Track Angle Rate";
        IsMandatory = false;
        
        LoadRawData(TrackAngleRateLength, buffer, offset);
        
        // TODO
    }
}