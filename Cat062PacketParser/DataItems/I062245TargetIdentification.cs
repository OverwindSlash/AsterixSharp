using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062245TargetIdentification : FixLengthDataItem
{
    public enum StiType
    {
        CallsignOrRegistrationDownlinkedFromTarget = 0,
        CallsignNotDownlinkedFromTarget = 1,
        RegistrationNotDownlinkedFromTarget = 2,
        Invalid = 3
    }
    
    public const int TargetIdentificationLength = 7;
    
    public StiType Sti { get; set; }
    public string CallSign { get; set; }
    
    public I062245TargetIdentification(byte[] buffer, int offset)
    {
        Name = "I062/245, Target Identification";
        IsMandatory = false;
        
        LoadRawData(TargetIdentificationLength, buffer, offset);

        var stiValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 2);
        Sti = (StiType)stiValue;

        CallSign = BitOperations.ConvertBytesTo6BitsAscii(RawData, 1,8);
    }
}