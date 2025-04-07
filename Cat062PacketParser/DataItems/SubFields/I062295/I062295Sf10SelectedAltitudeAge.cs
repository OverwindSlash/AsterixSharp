using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf10SelectedAltitudeAge : FixLengthDataItem
{
    public const int SelectedAltitudeAgeLength = 1;
    public const double LSB = 0.25;

    public double Sal { get; private set; }


    public I062295Sf10SelectedAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Selected Altitude Age";
        IsMandatory = false;
        
        LoadRawData(SelectedAltitudeAgeLength, buffer, offset);

        var salValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Sal = salValue * LSB;
    }
}