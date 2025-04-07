using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf20TrackAngleAge : FixLengthDataItem
{
    public const int TrackAngleAgeLength = 1;
    public const double LSB = 0.25;

    public double Tan { get; private set; }

    public I062295Sf20TrackAngleAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Track Angle Age";
        IsMandatory = false;
        
        LoadRawData(TrackAngleAgeLength, buffer, offset);

        var tanValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Tan = tanValue * LSB;
    }
}