using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf1SensorIdentification : FixLengthDataItem
{
    public const int SensorIdentificationLength = 2;

    public I062340Sf1SensorIdentification(byte[] buffer, int offset)
    {
        Name = "I062/340, Sensor Identification";
        IsMandatory = false;
        
        LoadRawData(SensorIdentificationLength, buffer, offset);
        
        // TODO
    }
}