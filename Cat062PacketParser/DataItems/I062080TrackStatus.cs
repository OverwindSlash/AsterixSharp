using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062080TrackStatus : ExtentableDataItem
{
    public enum SourceTrackTypes
    {
        NoSource = 0,
        Gnss = 1,
        Radar = 2,
        Triangulation = 3,
        HeightFromCoverage = 4,
        SpeedLookupTable = 5,
        DefaultHeight = 6,
        Multiateration = 7
    }
    
    public enum Mode4InterrogationTypes
    {
        NoMode4Interrogation = 0,
        FriendlyTarget = 1,
        UnknownTarget = 2,
        NoReply = 3
    }
    
    public enum Mode5InterrogationTypes
    {
        NoMode5Interrogation = 0,
        FriendlyTarget = 1,
        UnknownTarget = 2,
        NoReply = 3
    }
    
    public enum SurveillanceStatusTypes
    {
        Combined = 0,
        CoOperativeOnly = 1,
        NonCooperativeOnly = 2,
        NotDefined = 3
    }
    
    public enum EmergencyStatusTypes
    {
        NoEmergency = 0,
        GeneralEmergency = 1,
        LifeguardMedical = 2,
        MinimumFuel = 3,
        NoCommunications = 4,
        UnlawfulInterference = 5,
        DownedAircraft = 6,
        Undefined = 7
    }
    
    public const int MaxTrackStatusLength = 6;

    public bool IsMonoSensorTrack { get; private set; }
    public bool IsSpiPresent { get; private set; }
    public bool IsGeoAltitudeMoreReliable { get; private set; }
    public SourceTrackTypes SourceOfCalculatedTrack { get; private set; }
    public bool IsTentativeTrack { get; private set; }
    public bool Fx1 { get; private set; }

    public bool IsActualTrack { get; private set; }
    public bool IsTse { get; private set; }
    public bool IsTsb { get; private set; }
    public bool IsFlightPlanCorrelated { get; private set; }
    public bool IsAff { get; private set; }
    public bool IsSlaveTrackPromotion { get; private set; }
    public bool IsBackgroundServiceUsed { get; private set; }
    public bool Fx2 { get; private set; }

    public bool IsAmalgamation { get; private set; }
    public Mode4InterrogationTypes Mode4Interrogation { get; private set; }
    public bool IsMilitaryEmergency { get; private set; }
    public bool IsMilitaryIdentification { get; private set; }
    public Mode5InterrogationTypes Mode5Interrogation { get; private set; }
    public bool Fx3 { get; private set; }

    public bool IsCst { get; private set; }
    public bool IsPsr { get; private set; }
    public bool IsSsr { get; private set; }
    public bool IsMds { get; private set; }
    public bool IsAds { get; private set; }
    public bool IsSuc { get; private set; }
    public bool IsAac { get; private set; }
    public bool Fx4 { get; private set; }

    public SurveillanceStatusTypes SurveillanceDataStatus { get; private set; }
    public EmergencyStatusTypes EmergencyStatusIndication { get; private set; }
    public bool IsPotentialFalseTrackIndication { get; private set; }
    public bool IsTrackWithFplData { get; private set; }
    public bool Fx5 { get; private set; }

    public bool IsDuplicateMode3ACode { get; private set; }
    public bool IsDuplicateFlightPlan { get; private set; }
    public bool IsDuplicateFlightPlanDueToManualCorrelation { get; private set; }
    public bool SurfaceTarget { get; private set; }
    public bool IsDuplicateFlightId { get; private set; }
    public bool IsInconsistentEmergencyCode { get; private set; }
    public bool IsMlat { get; private set; }
    public bool Fx6 { get; private set; }

    public I062080TrackStatus(byte[] buffer, int offset)
    {
        Name = "I062/080, Track Status";
        IsMandatory = true;

        ParseExtentableData(MaxTrackStatusLength, buffer, offset);

        InitDefaultValues();

        IsMonoSensorTrack = BitOperations.GetBit(RawData, 0);
        IsSpiPresent = BitOperations.GetBit(RawData, 1);
        IsGeoAltitudeMoreReliable = BitOperations.GetBit(RawData, 2);
        SourceOfCalculatedTrack = (SourceTrackTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 3, 3);
        IsTentativeTrack = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        IsActualTrack = BitOperations.GetBit(RawData, 8);
        IsTse = BitOperations.GetBit(RawData, 9);
        IsTsb = BitOperations.GetBit(RawData, 10);
        IsFlightPlanCorrelated = BitOperations.GetBit(RawData, 11);
        IsAff = BitOperations.GetBit(RawData, 12);
        IsSlaveTrackPromotion = BitOperations.GetBit(RawData, 13);
        IsBackgroundServiceUsed = BitOperations.GetBit(RawData, 14);
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
        
        IsAmalgamation = BitOperations.GetBit(RawData, 16);
        Mode4Interrogation = (Mode4InterrogationTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 17, 2);
        IsMilitaryEmergency = BitOperations.GetBit(RawData, 19);
        IsMilitaryIdentification = BitOperations.GetBit(RawData, 20);
        Mode5Interrogation = (Mode5InterrogationTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 21, 2);
        Fx3 = BitOperations.GetBit(RawData, 23);
        if (!Fx3) return;
        
        IsCst = BitOperations.GetBit(RawData, 24);
        IsPsr = BitOperations.GetBit(RawData, 25);
        IsSsr = BitOperations.GetBit(RawData, 26);
        IsMds = BitOperations.GetBit(RawData, 27);
        IsAds = BitOperations.GetBit(RawData, 28);
        IsSuc = BitOperations.GetBit(RawData, 29);
        IsAac = BitOperations.GetBit(RawData, 30);
        Fx4 = BitOperations.GetBit(RawData, 31);
        if (!Fx4) return;
        
        SurveillanceDataStatus = (SurveillanceStatusTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 32, 2);
        EmergencyStatusIndication = (EmergencyStatusTypes)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 34, 3);
        IsPotentialFalseTrackIndication = BitOperations.GetBit(RawData, 37);
        IsTrackWithFplData = BitOperations.GetBit(RawData, 38);
        Fx5 = BitOperations.GetBit(RawData, 39);
        if (!Fx5) return;
        
        IsDuplicateMode3ACode = BitOperations.GetBit(RawData, 40);
        IsDuplicateFlightPlan = BitOperations.GetBit(RawData, 41);
        IsDuplicateFlightPlanDueToManualCorrelation = BitOperations.GetBit(RawData, 42);
        SurfaceTarget = BitOperations.GetBit(RawData, 43);
        IsDuplicateFlightId = BitOperations.GetBit(RawData, 44);
        IsInconsistentEmergencyCode = BitOperations.GetBit(RawData, 45);
        IsMlat = BitOperations.GetBit(RawData, 46);
        Fx6 = BitOperations.GetBit(RawData, 47);
        if (!Fx6) return;
    }

    private void InitDefaultValues()
    {
        SurveillanceDataStatus = SurveillanceStatusTypes.NotDefined;
        EmergencyStatusIndication = EmergencyStatusTypes.Undefined;
    }
}