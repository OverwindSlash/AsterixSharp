using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf13CommunicationAcasFlightStatusAge : FixLengthDataItem
{
    public const int CommunicationAcasFlightStatusAgeLength = 1;
    public const double LSB = 0.25;

    public double Com { get; private set; }

    public I062295Sf13CommunicationAcasFlightStatusAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Communication/ACAS Capability and Flight Status Age";  
        IsMandatory = false;
        
        LoadRawData(CommunicationAcasFlightStatusAgeLength, buffer, offset);

        var comValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 8);
        Com = comValue * LSB;
    }
}