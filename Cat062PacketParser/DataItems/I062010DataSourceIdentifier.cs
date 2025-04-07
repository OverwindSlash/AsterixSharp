using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062010DataSourceIdentifier : FixLengthDataItem
{
    public const int DataSourceIdentifierLength = 2;

    public byte SystemAreaCode { get; private set; }
    public byte SystemIdentificationCode { get; private set; }
    
    public I062010DataSourceIdentifier(byte[] buffer, int offset)
    {
        Name = "I062/010, Data Source Identifier";
        IsMandatory = true;
        
        LoadRawData(DataSourceIdentifierLength, buffer, offset);
        
        SystemAreaCode = RawData[0];
        SystemIdentificationCode = RawData[1];
    }
}