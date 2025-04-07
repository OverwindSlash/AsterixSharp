using AsterixCore;
using Cat062PacketParser.DataItems.SubFields;
using Cat062PacketParser.DataItems.SubFields.I062295;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062295TrackDataAges : ExtentableDataItemWithSubFields
{
    public const int MaxTrackDataAgesLength = 5;

    #region PrimarySubfield
        public bool HasMfl { get; private set; }
        public bool HasMd1 { get; private set; }
        public bool HasMd2 { get; private set; }
        public bool HasMdA { get; private set; }
        public bool HasMd4 { get; private set; }
        public bool HasMd5 { get; private set; }
        public bool HasMhg { get; private set; }
        public bool Fx1 { get; private set; }

        public bool HasIas { get; private set; }
        public bool HasTas { get; private set; }
        public bool HasSal { get; private set; }
        public bool HasFss { get; private set; }
        public bool HasTid { get; private set; }
        public bool HasCom { get; private set; }
        public bool HasSab { get; private set; }
        public bool Fx2 { get; private set; }

        public bool HasAcs { get; private set; }
        public bool HasBvr { get; private set; }
        public bool HasGvr { get; private set; }
        public bool HasRan { get; private set; }
        public bool HasTar { get; private set; }
        public bool HasTan { get; private set; }
        public bool HasGsp { get; private set; }
        public bool Fx3 { get; private set; }

        public bool HasVun { get; private set; }
        public bool HasMet { get; private set; }
        public bool HasEmc { get; private set; }
        public bool HasPos { get; private set; }
        public bool HasGal { get; private set; }
        public bool HasPun { get; private set; }
        public bool HasMb { get; private set; }
        public bool Fx4 { get; private set; }

        public bool HasIar { get; private set; }
        public bool HasMac { get; private set; }
        public bool HasBps { get; private set; }
        public bool Fx5 { get; private set; }
        #endregion
        
        #region Subfields
        public I062295Sf1MeasuredFlightLevelAge Mfl { get; private set; }
        public I062295Sf2Mode1Age Md1 { get; private set; }
        public I062295Sf3Mode2Age Md2 { get; private set; }
        public I062295Sf4Mode3AAge Mda { get; private set; }
        public I062295Sf5Mode4Age Md4 { get; private set; }
        public I062295Sf6Mode5Age Md5 { get; private set; }
        public I062295Sf7MagneticHeadingAge Mhg { get; private set; }
        public I062295Sf8IndicatedAirspeedAge Ias { get; private set; }
        public I062295Sf9TrueAirspeedAge Tas { get; private set; }
        public I062295Sf10SelectedAltitudeAge Sal { get; private set; }
        public I062295Sf11FinalStateSelectedAltitudeAge Fss { get; private set; }
        public I062295Sf12TrajectoryIntentAge Tid { get; private set; }
        public I062295Sf13CommunicationAcasFlightStatusAge Com { get; private set; }
        public I062295Sf14StatusReportedByAdsBAge Sab { get; private set; }
        public I062295Sf15AcasResolutionAdvisoryReportAge Acs { get; private set; }
        public I062295Sf16BarometricVerticalRateAge Bvr { get; private set; }
        public I062295Sf17GeometricalVerticalRateAge Gvr { get; private set; }
        public I062295Sf18RollAngleAge Ran { get; private set; }
        public I062295Sf19TrackAngleRateAge Tar { get; private set; }
        public I062295Sf20TrackAngleAge Tan { get; private set; }
        public I062295Sf21GroundSpeedAge Gsp { get; private set; }
        public I062295Sf22VelocityUncertaintyAge Vun { get; private set; }
        public I062295Sf23MeteorologicalDataAge Met { get; private set; }
        public I062295Sf24EmitterCategoryAge Emc { get; private set; }
        public I062295Sf25PositionAge Pos { get; private set; }
        public I062295Sf26GeometricAltitudeAge Gal { get; private set; }
        public I062295Sf27PositionUncertaintyAge Pun { get; private set; }
        public I062295Sf28ModeSMbDataAge Mb { get; private set; }
        public I062295Sf29IndicatedAirspeedDataAge Iar { get; private set; }
        public I062295Sf30MachNumberDataAge Mac { get; private set; }
        public I062295Sf31BarometricPressureSettingDataAge Bps { get; private set; }
    #endregion

    public I062295TrackDataAges(byte[] buffer, int offset)
    {
        Name = "I062/295, Track Data Ages";
        IsMandatory = false;
        
        ParseExtentableData(MaxTrackDataAgesLength, buffer, offset);
        offset += Length;

        ExtractSubFieldFlag();

        ParseSubFields(buffer, offset);
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasMfl)
        {
            Mfl = new I062295Sf1MeasuredFlightLevelAge(buffer, offset);
            offset += Mfl.Length;
            Length += Mfl.Length;
        }

        if (HasMd1)
        {
            Md1 = new I062295Sf2Mode1Age(buffer, offset);
            offset += Md1.Length;
            Length += Md1.Length;
        }

        if (HasMd2)
        {
            Md2 = new I062295Sf3Mode2Age(buffer, offset);
            offset += Md2.Length;
            Length += Md2.Length;
        }

        if (HasMdA)
        {
            Mda = new I062295Sf4Mode3AAge(buffer, offset);
            offset += Mda.Length;
            Length += Mda.Length;
        }

        if (HasMd4)
        {
            Md4 = new I062295Sf5Mode4Age(buffer, offset);
            offset += Md4.Length;
            Length += Md4.Length;
        }

        if (HasMd5)
        {
            Md5 = new I062295Sf6Mode5Age(buffer, offset);
            offset += Md5.Length;
            Length += Md5.Length;
        }

        if (HasMhg)
        {
            Mhg = new I062295Sf7MagneticHeadingAge(buffer, offset);
            offset += Mhg.Length;
            Length += Mhg.Length;
        }

        if (HasIas)
        {
            Ias = new I062295Sf8IndicatedAirspeedAge(buffer, offset);
            offset += Ias.Length;
            Length += Ias.Length;
        }

        if (HasTas)
        {
            Tas = new I062295Sf9TrueAirspeedAge(buffer, offset);
            offset += Tas.Length;
            Length += Tas.Length;
        }

        if (HasSal)
        {
            Sal = new I062295Sf10SelectedAltitudeAge(buffer, offset);
            offset += Sal.Length;
            Length += Sal.Length;
        }

        if (HasFss)
        {
            Fss = new I062295Sf11FinalStateSelectedAltitudeAge(buffer, offset);
            offset += Fss.Length;
            Length += Fss.Length;
        }

        if (HasTid)
        {
            Tid = new I062295Sf12TrajectoryIntentAge(buffer, offset);
            offset += Tid.Length;
            Length += Tid.Length;
        }

        if (HasCom)
        {
            Com = new I062295Sf13CommunicationAcasFlightStatusAge(buffer, offset);
            offset += Com.Length;
            Length += Com.Length;
        }

        if (HasSab)
        {
            Sab = new I062295Sf14StatusReportedByAdsBAge(buffer, offset);
            offset += Sab.Length;
            Length += Sab.Length;
        }

        if (HasAcs)
        {
            Acs = new I062295Sf15AcasResolutionAdvisoryReportAge(buffer, offset);
            offset += Acs.Length;
            Length += Acs.Length;
        }

        if (HasBvr)
        {
            Bvr = new I062295Sf16BarometricVerticalRateAge(buffer, offset);
            offset += Bvr.Length;
            Length += Bvr.Length;
        }

        if (HasGvr)
        {
            Gvr = new I062295Sf17GeometricalVerticalRateAge(buffer, offset);
            offset += Gvr.Length;
            Length += Gvr.Length;
        }

        if (HasRan)
        {
            Ran = new I062295Sf18RollAngleAge(buffer, offset);
            offset += Ran.Length;
            Length += Ran.Length;
        }

        if (HasTar)
        {
            Tar = new I062295Sf19TrackAngleRateAge(buffer, offset);
            offset += Tar.Length;
            Length += Tar.Length;
        }

        if (HasTan)
        {
            Tan = new I062295Sf20TrackAngleAge(buffer, offset);
            offset += Tan.Length;
            Length += Tan.Length;
        }

        if (HasGsp)
        {
            Gsp = new I062295Sf21GroundSpeedAge(buffer, offset);
            offset += Gsp.Length;
            Length += Gsp.Length;
        }

        if (HasVun)
        {
            Vun = new I062295Sf22VelocityUncertaintyAge(buffer, offset);
            offset += Vun.Length;
            Length += Vun.Length;
        }

        if (HasMet)
        {
            Met = new I062295Sf23MeteorologicalDataAge(buffer, offset);
            offset += Met.Length;
            Length += Met.Length;
        }

        if (HasEmc)
        {
            Emc = new I062295Sf24EmitterCategoryAge(buffer, offset);
            offset += Emc.Length;
            Length += Emc.Length;
        }

        if (HasPos)
        {
            Pos = new I062295Sf25PositionAge(buffer, offset);
            offset += Pos.Length;
            Length += Pos.Length;
        }

        if (HasGal)
        {
            Gal = new I062295Sf26GeometricAltitudeAge(buffer, offset);
            offset += Gal.Length;
            Length += Gal.Length;
        }

        if (HasPun)
        {
            Pun = new I062295Sf27PositionUncertaintyAge(buffer, offset);
            offset += Pun.Length;
            Length += Pun.Length;
        }

        if (HasMb)
        {
            Mb = new I062295Sf28ModeSMbDataAge(buffer, offset);
            offset += Mb.Length;
            Length += Mb.Length;
        }

        if (HasIar)
        {
            Iar = new I062295Sf29IndicatedAirspeedDataAge(buffer, offset);
            offset += Iar.Length;
            Length += Iar.Length;
        }

        if (HasMac)
        {
            Mac = new I062295Sf30MachNumberDataAge(buffer, offset);
            offset += Mac.Length;
            Length += Mac.Length;
        }

        if (HasBps)
        {
            Bps = new I062295Sf31BarometricPressureSettingDataAge(buffer, offset);
            offset += Bps.Length;
            Length += Bps.Length;
        }
    }

    private void ExtractSubFieldFlag()
    {
        HasMfl = BitOperations.GetBit(RawData, 0);
        HasMd1 = BitOperations.GetBit(RawData, 1);
        HasMd2 = BitOperations.GetBit(RawData, 2);
        HasMdA = BitOperations.GetBit(RawData, 3);
        HasMd4 = BitOperations.GetBit(RawData, 4);
        HasMd5 = BitOperations.GetBit(RawData, 5);
        HasMhg = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        HasIas = BitOperations.GetBit(RawData, 8);
        HasTas = BitOperations.GetBit(RawData, 9);
        HasSal = BitOperations.GetBit(RawData, 10);
        HasFss = BitOperations.GetBit(RawData, 11);
        HasTid = BitOperations.GetBit(RawData, 12);
        HasCom = BitOperations.GetBit(RawData, 13);
        HasSab = BitOperations.GetBit(RawData, 14);
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
        
        HasAcs = BitOperations.GetBit(RawData, 16);
        HasBvr = BitOperations.GetBit(RawData, 17);
        HasGvr = BitOperations.GetBit(RawData, 18);
        HasRan = BitOperations.GetBit(RawData, 19);
        HasTar = BitOperations.GetBit(RawData, 20);
        HasTan = BitOperations.GetBit(RawData, 21);
        HasGsp = BitOperations.GetBit(RawData, 22);
        Fx3 = BitOperations.GetBit(RawData, 23);
        if (!Fx3) return;
        
        HasVun = BitOperations.GetBit(RawData, 24);
        HasMet = BitOperations.GetBit(RawData, 25);
        HasEmc = BitOperations.GetBit(RawData, 26);
        HasPos = BitOperations.GetBit(RawData, 27);
        HasGal = BitOperations.GetBit(RawData, 28);
        HasPun = BitOperations.GetBit(RawData, 29);
        HasMb = BitOperations.GetBit(RawData, 30);
        Fx4 = BitOperations.GetBit(RawData, 31);
        if (!Fx4) return;
        
        HasIar = BitOperations.GetBit(RawData, 32);
        HasMac = BitOperations.GetBit(RawData, 33);
        HasBps = BitOperations.GetBit(RawData, 34);
        BitOperations.GetBit(RawData, 35);  // Spare
        BitOperations.GetBit(RawData, 36);  // Spare
        BitOperations.GetBit(RawData, 37);  // Spare
        BitOperations.GetBit(RawData, 38);  // Spare
        Fx5 = BitOperations.GetBit(RawData, 39);
        if (!Fx5) return;
    }
}