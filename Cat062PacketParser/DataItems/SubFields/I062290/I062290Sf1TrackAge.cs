using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf1TrackAge : FixLengthDataItem
{
    public const int TrackAgeLength = 1;

    public I062290Sf1TrackAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Track Age";
        IsMandatory = false;
        
        LoadRawData(TrackAgeLength, buffer, offset);
        
        // TODO
    }
}