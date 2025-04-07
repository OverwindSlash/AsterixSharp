using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf17GeometricalVerticalRateAge : FixLengthDataItem
{
    public const int GeometricalVerticalRateAgeLength = 1;
    public const double LSB = 0.25;

    public double Gvr { get; private set; }

    public I062295Sf17GeometricalVerticalRateAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Geometrical Vertical Rate Age";
        IsMandatory = false;
        
        LoadRawData(GeometricalVerticalRateAgeLength, buffer, offset);

        var gvrValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Gvr = gvrValue * LSB;
    }
}