using AsterixCore;
using Cat062PacketParser.DataItems.SubFields.I062110;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062110Mode5DataReportsExtendedMode1Code : ExtentableDataItemWithSubFields
{
    public const int PrimarySubFieldFlagLength = 1;
    
    #region PrimarySubfield
    public bool HasSum { get; private set; }
    public bool HasPmn { get; private set; }
    public bool HasPos { get; private set; }
    public bool HasGa { get; private set; }
    public bool HasEm1 { get; private set; }
    public bool HasTos { get; private set; }
    public bool HasXp { get; private set; }
    public bool Fx { get; private set; }
    #endregion
    
    #region Subfield Items
    public I062110Sf1Mode5Summary Summary { get; private set; }
    public I062110Sf2Mode5PinNationalOriginMissionCode PinNationalOriginMissionCode { get; private set; }
    public I062110Sf3Mode5ReportedPosition ReportedPosition { get; private set; }
    public I062110Sf4Mode5GnssDerivedAltitude GnssDerivedAltitude { get; private set; }
    public I062110Sf5ExtendedMode1CodeInOctalRepresentation ExtendedMode1CodeInOctalRepresentation { get; private set; }
    public I062110Sf6TimeOffsetForPosAndGa TimeOffsetForPosAndGa { get; private set; }
    public I062110Sf7XPulsePresence XPulsePresence { get; private set; }
    #endregion

    public I062110Mode5DataReportsExtendedMode1Code(byte[] buffer, int offset)
    {
        Name = "I062/110, Mode 5 Data reports & Extended Mode 1 Code";
        IsMandatory = false;
        
        ParseExtentableData(PrimarySubFieldFlagLength, buffer, offset);
    }

    private void ExtractSubFieldFlag()
    {
        HasSum = BitOperations.GetBit(RawData, 0);
        HasPmn = BitOperations.GetBit(RawData, 1);
        HasPos = BitOperations.GetBit(RawData, 2);
        HasGa = BitOperations.GetBit(RawData, 3);
        HasEm1 = BitOperations.GetBit(RawData, 4);
        HasTos = BitOperations.GetBit(RawData, 5);
        HasXp = BitOperations.GetBit(RawData, 6);
        Fx = BitOperations.GetBit(RawData, 7);
        if (!Fx) return;
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasSum)
        {
            Summary = new I062110Sf1Mode5Summary(buffer, offset);
            offset += Summary.Length;
            Length += Summary.Length;
        }

        if (HasPmn)
        {
            PinNationalOriginMissionCode = new I062110Sf2Mode5PinNationalOriginMissionCode(buffer, offset);
            offset += PinNationalOriginMissionCode.Length;
            Length += PinNationalOriginMissionCode.Length;
        }

        if (HasPos)
        {
            ReportedPosition = new I062110Sf3Mode5ReportedPosition(buffer, offset);
            offset += ReportedPosition.Length;
            Length += ReportedPosition.Length;
        }

        if (HasGa)
        {
            GnssDerivedAltitude = new I062110Sf4Mode5GnssDerivedAltitude(buffer, offset);
            offset += GnssDerivedAltitude.Length;
            Length += GnssDerivedAltitude.Length;
        }

        if (HasEm1)
        {
            ExtendedMode1CodeInOctalRepresentation = new I062110Sf5ExtendedMode1CodeInOctalRepresentation(buffer, offset);
            offset += ExtendedMode1CodeInOctalRepresentation.Length;
            Length += ExtendedMode1CodeInOctalRepresentation.Length;
        }

        if (HasTos)
        {
            TimeOffsetForPosAndGa = new I062110Sf6TimeOffsetForPosAndGa(buffer, offset);
            offset += TimeOffsetForPosAndGa.Length;
            Length += TimeOffsetForPosAndGa.Length;
        }

        if (HasXp)
        {
            XPulsePresence = new I062110Sf7XPulsePresence(buffer, offset);
            offset += XPulsePresence.Length;
            Length += XPulsePresence.Length;
        }
    }
}