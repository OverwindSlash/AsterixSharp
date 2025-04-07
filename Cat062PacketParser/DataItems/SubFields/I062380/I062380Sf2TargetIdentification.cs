using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf2TargetIdentification : FixLengthDataItem
{
    public const int TargetIdentificationLength = 6;

    public string TargetIdentification { get; set; }

    public I062380Sf2TargetIdentification(byte[] buffer, int offset)
    {
        Name = "I062/380, Target Identification";
        IsMandatory = false;
        
        LoadRawData(TargetIdentificationLength, buffer, offset);
        
        TargetIdentification = BitOperations.ConvertBytesTo6BitsAscii(RawData, 0, 8);
    }
}