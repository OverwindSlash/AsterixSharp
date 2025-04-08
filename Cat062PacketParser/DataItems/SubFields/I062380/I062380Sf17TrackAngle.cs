using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf17TrackAngle : FixLengthDataItem
{
    public const int TrackAngleLength = 2;
    public const double LSB = 0.0054931640625;

    public double Tan { get; private set; }

    public I062380Sf17TrackAngle(byte[] buffer, int offset)
    {
        Name = "I062/380, Track Angle";
        IsMandatory = false;
        
        LoadRawData(TrackAngleLength, buffer, offset);

        var tanValue = BitOperations.ConvertBitsBigEndianSigned(RawData, 0, 16);
        Tan = tanValue * LSB;
    }
}