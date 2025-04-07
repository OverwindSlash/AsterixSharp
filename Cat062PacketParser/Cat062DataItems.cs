using Cat062PacketParser.DataItems;

namespace Cat062PacketParser;

public class Cat062DataItems
{
    public I062010DataSourceIdentifier SourceIdentifier { get; private set; }
    public I062015ServiceIdentification ServiceIdentification { get; private set; }
    public I062070TimeOfTrackInformation TimeOfTrackInfo { get; private set; }
    public I062105CalculatedPositionInWGS84 PositionInWgs84 { get; private set; }
    public I062100CalculatedTrackPositionInCartesian PositionInCartesian { get; private set; }
    public I062185CalculatedTrackVelocityInCartesian TrackVelocityInCartesian { get; private set; }
    public I062210CalculatedAccelerationInCartesian AccelerationInCartesian { get; private set; }
    public I062060TrackMode3ACode TrackMode3ACode { get; private set; }
    public I062245TargetIdentification TargetIdentification { get; private set; }
    public I062380AircraftDerivedData AircraftDerivedData { get; private set; }
    public I062040TrackNumber TrackNumber { get; private set; }
    public I062080TrackStatus TrackStatus { get; private set; }
    public I062290SystemTrackUpdateAges SystemTrackUpdateAges { get; private set; }
    public I062200ModeOfMovement ModeOfMovement { get; private set; }
    public I062295TrackDataAges TrackDataAges { get; private set; }
    public I062136MeasuredFlightLevel MeasuredFlightLevel { get; private set; }
    public I062130CalculatedTrackGeometricAltitude TrackGeometricAltitude { get; private set; }
    public I062135CalculatedTrackBarometricAltitude TrackBarometricAltitude { get; private set; }
    public I062220CalculatedRateOfClimbDescent RateOfClimbDescent { get; private set; }
    public I062390FlightPlanRelatedData FlightPlanRelatedData { get; private set; }
    public I062270TargetSizeOrientation TargetSizeOrientation { get; private set; }
    public I062300VehicleFleetIdentification VehicleFleetIdentification { get; private set; }
    public I062110Mode5DataReportsExtendedMode1Code Mode5DataReportsExtendedMode1Code { get; private set; }
    public I062120TrackMode2Code TrackMode2Code { get; private set; }
    public I062510ComposedTrackNumber ComposedTrackNumber { get; private set; }
    public I062500EstimatedAccuracies EstimatedAccuracies { get; private set; }
    public I062340MeasuredInformation MeasuredInformation { get; private set; }

    public Cat062DataItems(Cat062Header header, byte[] buffer, int bufferSize)
    {
        int offset = header.Offset;
        
        // I062/010, Data Source Identifier，2 bytes
        if (header.HasDataSourceIdentifier)
        {
            SourceIdentifier = new I062010DataSourceIdentifier(buffer, offset);
            offset += SourceIdentifier.Length;
        }
        
        // I062/015, Service Identification, 1 byte
        if (header.HasServiceIdentification)
        {
            ServiceIdentification = new I062015ServiceIdentification(buffer, offset);
            offset += ServiceIdentification.Length;
        }
        
        // Item I062/070, Time Of Track Information, 3 bytes
        if (header.HasTimeOfTrackInformation)
        {
            TimeOfTrackInfo = new I062070TimeOfTrackInformation(buffer, offset);
            offset += TimeOfTrackInfo.Length;
        }
        
        // I062/105, Calculated Position In WGS-84 Co-ordinates，8 bytes
        if (header.HasCalculatedTrackPositionWgs84)
        {
            PositionInWgs84 = new I062105CalculatedPositionInWGS84(buffer, offset);
            offset += PositionInWgs84.Length;
        }
        
        // I062/100, Calculated Track Position. (Cartesian)，6 bytes
        if (header.HasCalculatedTrackPositionCartesian)
        {
            PositionInCartesian = new I062100CalculatedTrackPositionInCartesian(buffer, offset);
            offset += PositionInCartesian.Length;
        }
        
        // I062/185, Calculated Track Velocity (Cartesian), 4 bytes
        if (header.HasCalculatedTrackVelocityCartesian)
        {
            TrackVelocityInCartesian = new I062185CalculatedTrackVelocityInCartesian(buffer, offset);
            offset += TrackVelocityInCartesian.Length;
        }
        
        // I062/210, Calculated Acceleration (Cartesian), 2 bytes
        if (header.Fx1 && header.HasCalculatedAccelerationCartesian)
        {
            AccelerationInCartesian = new I062210CalculatedAccelerationInCartesian(buffer, offset);
            offset += AccelerationInCartesian.Length;
        }
        
        // I062/060, Track Mode 3/A Code, 2 bytes
        if (header.Fx1 && header.HasTrackMode3ACode)
        {
            TrackMode3ACode = new I062060TrackMode3ACode(buffer, offset);
            offset += TrackMode3ACode.Length;
        }
        
        // I062/245, Target Identification, 7 bytes
        if (header.Fx1 && header.HasTargetIdentification)
        {
            TargetIdentification = new I062245TargetIdentification(buffer, offset);
            offset += TargetIdentification.Length;
        }
        
        // I062/380, Aircraft Derived Data, 1+ bytes
        if (header.Fx1 && header.HasAircraftDerivedData)
        {
            AircraftDerivedData = new I062380AircraftDerivedData(buffer, offset);
            offset += AircraftDerivedData.Length;
        }
        
        // I062/040, Track Number, 2 bytes
        if (header.Fx1 && header.HasTrackNumber)
        {
            TrackNumber = new I062040TrackNumber(buffer, offset);
            offset += TrackNumber.Length;
        }
        
        // I062/080, Track Status, 1+ bytes
        if (header.Fx1 && header.HasTrackStatus)
        {
            TrackStatus = new I062080TrackStatus(buffer, offset);
            offset += TrackStatus.Length;
        }
        
        // I062/290,  System Track Update Ages, 1+ byte
        if (header.Fx1 && header.HasSystemTrackUpdateAges)
        {
            SystemTrackUpdateAges = new I062290SystemTrackUpdateAges(buffer, offset);
            offset += SystemTrackUpdateAges.Length;
        }
        
        // I062/200, Mode of Movement, 1 byte
        if (header.Fx2 && header.HasModeOfMovement)
        {
            ModeOfMovement = new I062200ModeOfMovement(buffer, offset);
            offset += ModeOfMovement.Length;
        }
        
        // I062/295,  Track Data Ages, 1+ byte
        if (header.Fx2 && header.HasTrackDataAges)
        {
            TrackDataAges = new I062295TrackDataAges(buffer, offset);
            offset += TrackDataAges.Length;
        }

        // I062/136, Measured Flight Level, 2 bytes
        if (header.Fx2 && header.HasMeasuredFlightLevel)
        {
            MeasuredFlightLevel = new I062136MeasuredFlightLevel(buffer, offset);
            offset += MeasuredFlightLevel.Length;
        }
        
        // I062/130, Calculated Track Geometric Altitude, 2 bytes
        if (header.Fx2 && header.HasCalculatedTrackGeometricAltitude)
        {
            TrackGeometricAltitude = new I062130CalculatedTrackGeometricAltitude(buffer, offset);
            offset += TrackGeometricAltitude.Length;
        }
        
        // I062/135, Calculated Track Barometric Altitude, 2 byte
        if (header.Fx2 && header.HasCalculatedTrackBarometricAltitude)
        {
            TrackBarometricAltitude = new I062135CalculatedTrackBarometricAltitude(buffer, offset);
            offset += TrackBarometricAltitude.Length;
        }
        
        // I062/220,  Calculated Rate Of Climb/Descent, 2 bytes
        if (header.Fx2 && header.HasCalculatedRateOfClimbDescent)
        {
            RateOfClimbDescent = new I062220CalculatedRateOfClimbDescent(buffer, offset);
            offset += RateOfClimbDescent.Length;
        }
        
        // I062/390,  Flight Plan Related Data, 1+ bytes
        if (header.Fx2 && header.HasFlightPlanRelatedData)
        {
            FlightPlanRelatedData = new I062390FlightPlanRelatedData(buffer, offset);
            offset += FlightPlanRelatedData.Length;
        }
        
        // I062/270,  Target Size & Orientation, 1+ bytes
        if (header.Fx3 && header.HasFlightPlanRelatedData)
        {
            TargetSizeOrientation = new I062270TargetSizeOrientation(buffer, offset);
            offset += TargetSizeOrientation.Length;
        }
        
        // I062/300,  Vehicle Fleet Identification, 1 bytes
        if (header.Fx3 && header.HasVehicleFleetIdentification)
        {
            VehicleFleetIdentification = new I062300VehicleFleetIdentification(buffer, offset);
            offset += VehicleFleetIdentification.Length;
        }
        
        // I062/110, Mode 5 Data reports & Extended Mode 1 Code, 1+ bytes
        if (header.Fx3 && header.HasMode5DataReportsAndExtendedMode1Code)
        {
            Mode5DataReportsExtendedMode1Code = new I062110Mode5DataReportsExtendedMode1Code(buffer, offset);
            offset += Mode5DataReportsExtendedMode1Code.Length;
        }
        
        // I062/120, Track Mode 2 Code, 2 byte
        if (header.Fx3 && header.HasTrackMode2Code)
        {
            TrackMode2Code = new I062120TrackMode2Code(buffer, offset);
            offset += TrackMode2Code.Length;
        }
        
        // I062/510, Composed Track Number, 3+ bytes
        if (header.Fx3 && header.HasComposedTrackNumber)
        {
            ComposedTrackNumber = new I062510ComposedTrackNumber(buffer, offset);
            offset += ComposedTrackNumber.Length;
        }
        
        // I062/500, Estimated Accuracies, 1+ bytes
        if (header.Fx3 && header.HasEstimatedAccuracies)
        {
            EstimatedAccuracies = new I062500EstimatedAccuracies(buffer, offset);
            offset += EstimatedAccuracies.Length;
        }
        
        // I062/340,  Measured Information, 1+ bytes
        if (header.Fx3 && header.HasMeasuredInformation)
        {
            MeasuredInformation = new I062340MeasuredInformation(buffer, offset);
            offset += MeasuredInformation.Length;
        }
    }
}