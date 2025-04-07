using AsterixCore;
using Cat062PacketParser.DataItems.SubFields.I062390;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062390FlightPlanRelatedData : ExtentableDataItemWithSubFields
{
    public const int MaxFlightPlanRelatedDataLength = 3;

    #region PrimarySubfield
    public bool HasTag { get; private set; }
    public bool HasCsn { get; private set; }
    public bool HasIfi { get; private set; }
    public bool HasFct { get; private set; }
    public bool HasTac { get; private set; }
    public bool HasWtc { get; private set; }
    public bool HasDep { get; private set; }
    public bool Fx1 { get; private set; }

    public bool HasDst { get; private set; }
    public bool HasRds { get; private set; }
    public bool HasCfl { get; private set; }
    public bool HasCtl { get; private set; }
    public bool HasTod { get; private set; }
    public bool HasAst { get; private set; }
    public bool HasSts { get; private set; }
    public bool Fx2 { get; private set; }

    public bool HasStd { get; private set; }
    public bool HasSta { get; private set; }
    public bool HasPem { get; private set; }
    public bool HasPec { get; private set; }
    public bool Fx3 { get; private set; }
    #endregion
    
    #region Subfield Items
    public I062390Sf1FppsIdentificationTag FppsIdentificationTag { get; private set; }
    public I062390Sf2CallSign CallSign { get; private set; }
    public I062390Sf3IfpsFlightId IfpsFlightId { get; private set; }
    public I062390Sf4FlightCategory FlightCategory { get; private set; }
    public I062390Sf5TypeOfAircraft TypeOfAircraft { get; private set; }
    public I062390Sf6WakeTurbulenceCategory WakeTurbulenceCategory { get; private set; }
    public I062390Sf7DepartureAirport DepartureAirport { get; private set; }
    public I062390Sf8DestinationAirport DestinationAirport { get; private set; }
    public I062390Sf9RunwayDesignation RunwayDesignation { get; private set; }
    public I062390Sf10CurrentClearedFlightLevel CurrentClearedFlightLevel { get; private set; }
    public I062390Sf11CurrentControlPosition CurrentControlPosition { get; private set; }
    public I062390Sf12TimeOfDepartureArrival TimeOfDepartureArrival { get; private set; }
    public I062390Sf13AircraftStand AircraftStand { get; private set; }
    public I062390Sf14StandStatus StandStatus { get; private set; }
    public I062390Sf15StandardInstrumentDeparture StandardInstrumentDeparture { get; private set; }
    public I062390Sf16StandardInstrumentArrival StandardInstrumentArrival { get; private set; }
    public I062390Sf17PreEmergencyMode3A PreEmergencyMode3A { get; private set; }
    public I062390Sf18PreEmergencyCallsign PreEmergencyCallsign { get; private set; }
    #endregion

    public I062390FlightPlanRelatedData(byte[] buffer, int offset)
    {
        Name = "I062/390, Flight Plan Related Data";
        IsMandatory = false;
        
        ParseExtentableData(MaxFlightPlanRelatedDataLength, buffer, offset);
        offset += Length;

        ExtractSubFieldFlag();
        
        ParseSubFields(buffer, offset);
    }

    private void ExtractSubFieldFlag()
    {
        HasTag = BitOperations.GetBit(RawData, 0);
        HasCsn = BitOperations.GetBit(RawData, 1);
        HasIfi = BitOperations.GetBit(RawData, 2);
        HasFct = BitOperations.GetBit(RawData, 3);
        HasTac = BitOperations.GetBit(RawData, 4);
        HasWtc = BitOperations.GetBit(RawData, 5);
        HasDep = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        HasDst = BitOperations.GetBit(RawData, 8);
        HasRds = BitOperations.GetBit(RawData, 9);
        HasCfl = BitOperations.GetBit(RawData, 10);
        HasCtl = BitOperations.GetBit(RawData, 11);
        HasTod = BitOperations.GetBit(RawData, 12);
        HasAst = BitOperations.GetBit(RawData, 13);
        HasSts = BitOperations.GetBit(RawData, 14);
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
        
        HasStd = BitOperations.GetBit(RawData, 16);
        HasSta = BitOperations.GetBit(RawData, 17);
        HasPem = BitOperations.GetBit(RawData, 18);
        HasPec = BitOperations.GetBit(RawData, 19);
        // BitOperations.GetBit(RawData, 20); // Spare
        // BitOperations.GetBit(RawData, 21); // Spare
        // BitOperations.GetBit(RawData, 22); // Spare
        Fx3 = BitOperations.GetBit(RawData, 23);
        if (!Fx3) return;
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasTag)
        {
            FppsIdentificationTag = new I062390Sf1FppsIdentificationTag(buffer, offset);
            offset += FppsIdentificationTag.Length;
            Length += FppsIdentificationTag.Length;
        }

        if (HasCsn)
        {
            CallSign = new I062390Sf2CallSign(buffer, offset);
            offset += CallSign.Length;
            Length += CallSign.Length;
        }

        if (HasIfi)
        {
            IfpsFlightId = new I062390Sf3IfpsFlightId(buffer, offset);
            offset += IfpsFlightId.Length;
            Length += IfpsFlightId.Length;
        }

        if (HasFct)
        {
            FlightCategory = new I062390Sf4FlightCategory(buffer, offset);
            offset += FlightCategory.Length;
            Length += FlightCategory.Length;
        }

        if (HasTac)
        {
            TypeOfAircraft = new I062390Sf5TypeOfAircraft(buffer, offset);
            offset += TypeOfAircraft.Length;
            Length += TypeOfAircraft.Length;
        }

        if (HasWtc)
        {
            WakeTurbulenceCategory = new I062390Sf6WakeTurbulenceCategory(buffer, offset);
            offset += WakeTurbulenceCategory.Length;
            Length += WakeTurbulenceCategory.Length;
        }

        if (HasDep)
        {
            DepartureAirport = new I062390Sf7DepartureAirport(buffer, offset);
            offset += DepartureAirport.Length;
            Length += DepartureAirport.Length;
        }

        if (HasDst)
        {
            DestinationAirport = new I062390Sf8DestinationAirport(buffer, offset);
            offset += DestinationAirport.Length;
            Length += DestinationAirport.Length;
        }

        if (HasRds)
        {
            RunwayDesignation = new I062390Sf9RunwayDesignation(buffer, offset);
            offset += RunwayDesignation.Length;
            Length += RunwayDesignation.Length;
        }

        if (HasCfl)
        {
            CurrentClearedFlightLevel = new I062390Sf10CurrentClearedFlightLevel(buffer, offset);
            offset += CurrentClearedFlightLevel.Length;
            Length += CurrentClearedFlightLevel.Length;
        }

        if (HasCtl)
        {
            CurrentControlPosition = new I062390Sf11CurrentControlPosition(buffer, offset);
            offset += CurrentControlPosition.Length;
            Length += CurrentControlPosition.Length;
        }

        if (HasTod)
        {
            TimeOfDepartureArrival = new I062390Sf12TimeOfDepartureArrival(buffer, offset);
            offset += TimeOfDepartureArrival.Length;
            Length += TimeOfDepartureArrival.Length;
        }

        if (HasAst)
        {
            AircraftStand = new I062390Sf13AircraftStand(buffer, offset);
            offset += AircraftStand.Length;
            Length += AircraftStand.Length;
        }

        if (HasSts)
        {
            StandStatus = new I062390Sf14StandStatus(buffer, offset);
            offset += StandStatus.Length;
            Length += StandStatus.Length;
        }

        if (HasStd)
        {
            StandardInstrumentDeparture = new I062390Sf15StandardInstrumentDeparture(buffer, offset);
            offset += StandardInstrumentDeparture.Length;
            Length += StandardInstrumentDeparture.Length;
        }

        if (HasSta)
        {
            StandardInstrumentArrival = new I062390Sf16StandardInstrumentArrival(buffer, offset);
            offset += StandardInstrumentArrival.Length;
            Length += StandardInstrumentArrival.Length;
        }

        if (HasPem)
        {
            PreEmergencyMode3A = new I062390Sf17PreEmergencyMode3A(buffer, offset);
            offset += PreEmergencyMode3A.Length;
            Length += PreEmergencyMode3A.Length;
        }

        if (HasPec)
        {
            PreEmergencyCallsign = new I062390Sf18PreEmergencyCallsign(buffer, offset);
            offset += PreEmergencyCallsign.Length;
            Length += PreEmergencyCallsign.Length;
        }
    }
}