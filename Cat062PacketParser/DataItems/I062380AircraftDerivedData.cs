using AsterixCore;
using Cat062PacketParser.DataItems.SubFields;
using Cat062PacketParser.DataItems.SubFields.I062380;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062380AircraftDerivedData : ExtentableDataItemWithSubFields
{
    public const int MaxAircraftDerivedDataLength = 4;
    
    #region PrimarySubfield
    public bool HasAdr { get; private set; }
    public bool HasId { get; private set; }
    public bool HasMhg { get; private set; }
    public bool HasIas { get; private set; }
    public bool HasTas { get; private set; }
    public bool HasSal { get; private set; }
    public bool HasFss { get; private set; }
    public bool Fx1 { get; private set; }

    public bool HasTis { get; private set; }
    public bool HasTid { get; private set; }
    public bool HasCom { get; private set; }
    public bool HasSab { get; private set; }
    public bool HasAcs { get; private set; }
    public bool HasBvr { get; private set; }
    public bool HasGvr { get; private set; }
    public bool Fx2 { get; private set; }

    public bool HasRan { get; private set; }
    public bool HasTar { get; private set; }
    public bool HasTan { get; private set; }
    public bool HasGsp { get; private set; }
    public bool HasVun { get; private set; }
    public bool HasMet { get; private set; }
    public bool HasEmc { get; private set; }
    public bool Fx3 { get; private set; }

    public bool HasPos { get; private set; }
    public bool HasGal { get; private set; }
    public bool HasPun { get; private set; }
    public bool HasMb { get; private set; }
    public bool HasIar { get; private set; }
    public bool HasMac { get; private set; }
    public bool HasBps { get; private set; }
    public bool Fx4 { get; private set; }
    #endregion
    
    #region Subfield Items
    public I062380Sf1TargetAddress TargetAddress { get; private set; }
    public I062380Sf2TargetIdentification TargetIdentification { get; private set; }
    public I062380Sf3MagneticHeading MagneticHeading { get; private set; }
    public I062380Sf4IndicatedAirspeed IndicatedAirspeed { get; private set; }
    public I062380Sf5TrueAirspeed TrueAirspeed { get; private set; }
    public I062380Sf6SelectedAltitude SelectedAltitude { get; private set; }
    public I062380Sf7FinalStateSelectedAltitude FinalStateSelectedAltitude { get; private set; }
    public I062380Sf8TrajectoryIntentStatus TrajectoryIntentStatus { get; private set; }
    public I062380Sf9TrajectoryIntentData TrajectoryIntentData { get; private set; }
    public I062380Sf10CommAcasFlightStatus CommAcasFlightStatus { get; private set; }
    public I062380Sf11StatusReportedByAdsB StatusReportedByAdsB { get; private set; }
    public I062380Sf12AcasResolutionAdvisoryReport AcasResolutionAdvisoryReport { get; private set; }
    public I062380Sf13BarometricVerticalRate BarometricVerticalRate { get; private set; }
    public I062380Sf14GeometricVerticalRate GeometricVerticalRate { get; private set; }
    public I062380Sf15RollAngle RollAngle { get; private set; }
    public I062380Sf16TrackAngleRate TrackAngleRate { get; private set; }
    public I062380Sf17TrackAngle TrackAngle { get; private set; }
    public I062380Sf18GroundSpeed GroundSpeed { get; private set; }
    public I062380Sf19VelocityUncertainty VelocityUncertainty { get; private set; }
    public I062380Sf20MetData MetData { get; private set; }
    public I062380Sf21EmitterCategory EmitterCategory { get; private set; }
    public I062380Sf22Position Position { get; private set; }
    public I062380Sf23GeometricAltitude GeometricAltitude { get; private set; }
    public I062380Sf24PositionUncertainty PositionUncertainty { get; private set; }
    public I062380Sf25BdsRegisterData BdsRegisterData { get; private set; }
    public I062380Sf26IndicatedAirspeed IndicatedAirspeedSubField { get; private set; }
    public I062380Sf27MachNumber MachNumber { get; private set; }
    public I062380Sf28BarometricPressureSetting BarometricPressureSetting { get; private set; }
    #endregion
    
    public I062380AircraftDerivedData(byte[] buffer, int offset)
    {
        Name = "I062/380, Aircraft Derived Data";
        IsMandatory = false;
        
        ParseExtentableData(MaxAircraftDerivedDataLength, buffer, offset);
        offset += Length;
        
        ExtractSubFieldFlag();

        ParseSubFields(buffer, offset);
    }
    
    private void ExtractSubFieldFlag()
    {
        HasAdr = BitOperations.GetBit(RawData, 0);
        HasId = BitOperations.GetBit(RawData, 1);
        HasMhg = BitOperations.GetBit(RawData, 2);
        HasIas = BitOperations.GetBit(RawData, 3);
        HasTas = BitOperations.GetBit(RawData, 4);
        HasSal = BitOperations.GetBit(RawData, 5);
        HasFss = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        HasTis = BitOperations.GetBit(RawData, 8);
        HasTid = BitOperations.GetBit(RawData, 9);
        HasCom = BitOperations.GetBit(RawData, 10);
        HasSab = BitOperations.GetBit(RawData, 11);
        HasAcs = BitOperations.GetBit(RawData, 12);
        HasBvr = BitOperations.GetBit(RawData, 13);
        HasGvr = BitOperations.GetBit(RawData, 14);
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
        
        HasRan = BitOperations.GetBit(RawData, 16);
        HasTar = BitOperations.GetBit(RawData, 17);
        HasTan = BitOperations.GetBit(RawData, 18);
        HasGsp = BitOperations.GetBit(RawData, 19);
        HasVun = BitOperations.GetBit(RawData, 20);
        HasMet = BitOperations.GetBit(RawData, 21);
        HasEmc = BitOperations.GetBit(RawData, 22);
        Fx3 = BitOperations.GetBit(RawData, 23);
        if (!Fx3) return;
        
        HasPos = BitOperations.GetBit(RawData, 24);
        HasGal = BitOperations.GetBit(RawData, 25);
        HasPun = BitOperations.GetBit(RawData, 26);
        HasMb = BitOperations.GetBit(RawData, 27);
        HasIar = BitOperations.GetBit(RawData, 28);
        HasMac = BitOperations.GetBit(RawData, 29);
        HasBps = BitOperations.GetBit(RawData, 30);
        Fx4 = BitOperations.GetBit(RawData, 31);
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasAdr)
        {
            TargetAddress = new I062380Sf1TargetAddress(buffer, offset);
            offset += TargetAddress.Length;
            Length += TargetAddress.Length;
        }

        if (HasId)
        {
            TargetIdentification = new I062380Sf2TargetIdentification(buffer, offset);
            offset += TargetIdentification.Length;
            Length += TargetIdentification.Length;
        }

        if (HasMhg)
        {
            MagneticHeading = new I062380Sf3MagneticHeading(buffer, offset);
            offset += MagneticHeading.Length;
            Length += MagneticHeading.Length;
        }

        if (HasIas)
        {
            IndicatedAirspeed = new I062380Sf4IndicatedAirspeed(buffer, offset);
            offset += IndicatedAirspeed.Length;
            Length += IndicatedAirspeed.Length;
        }

        if (HasTas)
        {
            TrueAirspeed = new I062380Sf5TrueAirspeed(buffer, offset);
            offset += TrueAirspeed.Length;
            Length += TrueAirspeed.Length;
        }

        if (HasSal)
        {
            SelectedAltitude = new I062380Sf6SelectedAltitude(buffer, offset);
            offset += SelectedAltitude.Length;
            Length += SelectedAltitude.Length;
        }

        if (HasFss)
        {
            FinalStateSelectedAltitude = new I062380Sf7FinalStateSelectedAltitude(buffer, offset);
            offset += FinalStateSelectedAltitude.Length;
            Length += FinalStateSelectedAltitude.Length;
        }

        if (HasTis)
        {
            TrajectoryIntentStatus = new I062380Sf8TrajectoryIntentStatus(buffer, offset);
            offset += TrajectoryIntentStatus.Length;
            Length += TrajectoryIntentStatus.Length;
        }

        if (HasTid)
        {
            TrajectoryIntentData = new I062380Sf9TrajectoryIntentData(buffer, offset);
            offset += TrajectoryIntentData.Length;
            Length += TrajectoryIntentData.Length;
        }

        if (HasCom)
        {
            CommAcasFlightStatus = new I062380Sf10CommAcasFlightStatus(buffer, offset);
            offset += CommAcasFlightStatus.Length;
            Length += CommAcasFlightStatus.Length;
        }

        if (HasSab)
        {
            StatusReportedByAdsB = new I062380Sf11StatusReportedByAdsB(buffer, offset);
            offset += StatusReportedByAdsB.Length;
            Length += StatusReportedByAdsB.Length;
        }

        if (HasAcs)
        {
            AcasResolutionAdvisoryReport = new I062380Sf12AcasResolutionAdvisoryReport(buffer, offset);
            offset += AcasResolutionAdvisoryReport.Length;
            Length += AcasResolutionAdvisoryReport.Length;
        }

        if (HasBvr)
        {
            BarometricVerticalRate = new I062380Sf13BarometricVerticalRate(buffer, offset);
            offset += BarometricVerticalRate.Length;
            Length += BarometricVerticalRate.Length;
        }

        if (HasGvr)
        {
            GeometricVerticalRate = new I062380Sf14GeometricVerticalRate(buffer, offset);
            offset += GeometricVerticalRate.Length;
            Length += GeometricVerticalRate.Length;
        }

        if (HasRan)
        {
            RollAngle = new I062380Sf15RollAngle(buffer, offset);
            offset += RollAngle.Length;
            Length += RollAngle.Length;
        }

        if (HasTar)
        {
            TrackAngleRate = new I062380Sf16TrackAngleRate(buffer, offset);
            offset += TrackAngleRate.Length;
            Length += TrackAngleRate.Length;
        }

        if (HasTan)
        {
            TrackAngle = new I062380Sf17TrackAngle(buffer, offset);
            offset += TrackAngle.Length;
            Length += TrackAngle.Length;
        }

        if (HasGsp)
        {
            GroundSpeed = new I062380Sf18GroundSpeed(buffer, offset);
            offset += GroundSpeed.Length;
            Length += GroundSpeed.Length;
        }

        if (HasVun)
        {
            VelocityUncertainty = new I062380Sf19VelocityUncertainty(buffer, offset);
            offset += VelocityUncertainty.Length;
            Length += VelocityUncertainty.Length;
        }

        if (HasMet)
        {
            MetData = new I062380Sf20MetData(buffer, offset);
            offset += MetData.Length;
            Length += MetData.Length;
        }

        if (HasEmc)
        {
            EmitterCategory = new I062380Sf21EmitterCategory(buffer, offset);
            offset += EmitterCategory.Length;
            Length += EmitterCategory.Length;
        }

        if (HasPos)
        {
            Position = new I062380Sf22Position(buffer, offset);
            offset += Position.Length;
            Length += Position.Length;
        }

        if (HasGal)
        {
            GeometricAltitude = new I062380Sf23GeometricAltitude(buffer, offset);
            offset += GeometricAltitude.Length;
            Length += GeometricAltitude.Length;
        }

        if (HasPun)
        {
            PositionUncertainty = new I062380Sf24PositionUncertainty(buffer, offset);
            offset += PositionUncertainty.Length;
            Length += PositionUncertainty.Length;
        }

        if (HasMb)
        {
            BdsRegisterData = new I062380Sf25BdsRegisterData(buffer, offset);
            offset += BdsRegisterData.Length;
            Length += BdsRegisterData.Length;
        }

        if (HasIar)
        {
            IndicatedAirspeedSubField = new I062380Sf26IndicatedAirspeed(buffer, offset);
            offset += IndicatedAirspeedSubField.Length;
            Length += IndicatedAirspeedSubField.Length;
        }

        if (HasMac)
        {
            MachNumber = new I062380Sf27MachNumber(buffer, offset);
            offset += MachNumber.Length;
            Length += MachNumber.Length;
        }

        if (HasBps)
        {
            BarometricPressureSetting = new I062380Sf28BarometricPressureSetting(buffer, offset);
            offset += BarometricPressureSetting.Length;
            Length += BarometricPressureSetting.Length;
        }
    }
}