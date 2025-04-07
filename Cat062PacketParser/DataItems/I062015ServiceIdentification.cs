using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062015ServiceIdentification : FixLengthDataItem
{
    public const int ServiceIdentificationLength = 1;
    
    public byte ServiceIdentification { get; private set; }

    public I062015ServiceIdentification(byte[] buffer, int offset)
    {
        Name = "I062/015, Service Identification";
        IsMandatory = false;
        
        LoadRawData(ServiceIdentificationLength, buffer, offset);
        
        ServiceIdentification = RawData[0];
    }
}