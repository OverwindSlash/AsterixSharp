using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062136MeasuredFlightLevel : FixLengthDataItem
{
    public const int MeasuredFlightLevelLength = 2;

    public const double LSB = 0.25;
    
    public double MeasuredFlightLevel { get; private set; }

    public I062136MeasuredFlightLevel(byte[] buffer, int offset)
    {
        Name = "I062/136, Measured Flight Level";
        IsMandatory = false;
        
        LoadRawData(MeasuredFlightLevelLength, buffer, offset);

        var levelValue = BitOperations.Get2BytesSignedBigEndian(RawData, 0);
        MeasuredFlightLevel = levelValue * LSB;
    }
}