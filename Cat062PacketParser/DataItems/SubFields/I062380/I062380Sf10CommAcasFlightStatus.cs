using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf10CommAcasFlightStatus : FixLengthDataItem
{
    public const int CommAcasFlightStatusLength = 2;

    public I062380Sf10CommAcasFlightStatus(byte[] buffer, int offset)
    {
        Name = "I062/380, Communications/ACAS Capability and Flight Status reported by Mode-S";
        IsMandatory = false;
        
        LoadRawData(CommAcasFlightStatusLength, buffer, offset);
        
        // TODO
    }
}