using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf13CommunicationAcasFlightStatusAge : FixLengthDataItem
{
    public const int CommunicationAcasFlightStatusAgeLength = 1;

    public I062295Sf13CommunicationAcasFlightStatusAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Communication/ACAS Capability and Flight Status Age";  
        IsMandatory = false;
        
        LoadRawData(CommunicationAcasFlightStatusAgeLength, buffer, offset);
        
        // TODO
    }
}