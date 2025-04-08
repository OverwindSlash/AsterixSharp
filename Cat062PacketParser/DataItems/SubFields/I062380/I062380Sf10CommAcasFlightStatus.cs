using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf10CommAcasFlightStatus : FixLengthDataItem
{
    public enum CommCapabilityTypes
    {
        NoCommCapability = 0,
        CommAAndCommB = 1,
        CommAAndCommBAndUplink = 2,
        CommAAndCommBAndUplinkAndDownlink = 3,
        Level5Transponder = 4
    }

    public enum FlightStatusTypes
    {
        NoAlertNoSpiAircraftAirborne = 0,
        NoAlertNoSpiAircraftOnGround = 1,
        AlertNoSpiAircraftAirborne = 2,
        AlertNoSpiAircraftOnGround = 3,
        AlertSpiAircraftAirborneOrOnGround = 4,
        NoAlertSpiAircraftAirborneOrOnGround = 5,
        NotDefined = 6,
        UnknownOrNotYetExtracted = 7
    }

    public const int CommAcasFlightStatusLength = 2;

    public CommCapabilityTypes CommCapability { get; private set; }
    public FlightStatusTypes FlightStatus { get; private set; }
    public bool IsSpecificServiceCapability { get; private set; }
    public bool IsAltitudeReportingCapability { get; private set; }
    public bool IsAircraftIdentificationCapability { get; private set; }
    public bool B1A { get; private set; }
    public byte B1B { get; private set; }

    public I062380Sf10CommAcasFlightStatus(byte[] buffer, int offset)
    {
        Name = "I062/380, Communications/ACAS Capability and Flight Status reported by Mode-S";
        IsMandatory = false;
        
        LoadRawData(CommAcasFlightStatusLength, buffer, offset);

        CommCapability = (CommCapabilityTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 3);
        FlightStatus = (FlightStatusTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 3, 3);
        // BitOperations.GetBit(RawData, 6); // Spare
        // BitOperations.GetBit(RawData, 7); // Spare
        IsSpecificServiceCapability = BitOperations.GetBit(RawData, 8);
        IsAltitudeReportingCapability = BitOperations.GetBit(RawData, 9);
        IsAircraftIdentificationCapability = BitOperations.GetBit(RawData, 10);
        B1A = BitOperations.GetBit(RawData, 11);
        B1B = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 12, 4);
    }
}