using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062290;

public class I062290Sf1TrackAge : FixLengthDataItem
{
    public const int TrackAgeLength = 1;
    public const double LSB = 0.25;

    public double Trk { get; private set; }

    public I062290Sf1TrackAge(byte[] buffer, int offset)
    {
        Name = "I062/290, Track Age";
        IsMandatory = false;
        
        LoadRawData(TrackAgeLength, buffer, offset);

        var trkValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Trk = trkValue * LSB;
    }
}