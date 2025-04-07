using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf19TrackAngleRateAge : FixLengthDataItem
{
    public const int TrackAngleRateAgeLength = 1;
    public const double LSB = 0.25;

    public double Tar { get; private set; }

    public I062295Sf19TrackAngleRateAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Track Angle Rate Age";
        IsMandatory = false;
        
        LoadRawData(TrackAngleRateAgeLength, buffer, offset);

        var tarValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Tar = tarValue * LSB;
    }
}