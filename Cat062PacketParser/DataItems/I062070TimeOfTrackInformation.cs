using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062070TimeOfTrackInformation : FixLengthDataItem
{
    public const int TimeOfTrackInformationLength = 3;
    public const float LSB = 1 / 128f;
    
    public float TimeOfTrackInSecond { get; private set; }
    
    public I062070TimeOfTrackInformation(byte[] buffer, int offset)
    {
        Name = "I062/070, Time Of Track Information";
        IsMandatory = true;
        
        LoadRawData(TimeOfTrackInformationLength, buffer, offset);

        var value = BitOperations.Get3BytesUnSignedBigEndian(RawData, 0);
        TimeOfTrackInSecond = value * LSB;
    }
}