using Cat062PacketParser;
using Cat062PacketParser.DataItems;
using Cat062PacketParser.DataItems.SubFields.I062340;

namespace Cat062DataItemsTests;

public class Cat062DataItemsTests
{
    private byte[] _buffer;

    private byte[] LoadCambridgePixelSimulatorData()
    {
        return File.ReadAllBytes("data/cat062-boat3.bin"); 
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);
        
        Assert.That(cat062DataItems.SourceIdentifier, Is.Not.Null);
        Assert.That(cat062DataItems.TimeOfTrackInfo, Is.Not.Null);
        Assert.That(cat062DataItems.PositionInWgs84, Is.Not.Null);
        Assert.That(cat062DataItems.PositionInCartesian, Is.Not.Null);
        Assert.That(cat062DataItems.TrackVelocityInCartesian, Is.Not.Null);
        Assert.That(cat062DataItems.TargetIdentification, Is.Not.Null);
        Assert.That(cat062DataItems.AircraftDerivedData, Is.Not.Null);
        Assert.That(cat062DataItems.TrackNumber, Is.Not.Null);
        Assert.That(cat062DataItems.TrackStatus, Is.Not.Null);
        Assert.That(cat062DataItems.TrackGeometricAltitude, Is.Not.Null);
        Assert.That(cat062DataItems.MeasuredInformation, Is.Not.Null);
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckSourceIdentifier()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var sourceIdentifier = cat062DataItems.SourceIdentifier;

        Assert.That(sourceIdentifier.Name, Is.EqualTo("I062/010, Data Source Identifier"));
        Assert.That(sourceIdentifier.IsMandatory, Is.True);
        Assert.That(sourceIdentifier.SystemAreaCode, Is.EqualTo(0));
        Assert.That(sourceIdentifier.SystemIdentificationCode, Is.EqualTo(1));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTimeOfTrackInfo()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var timeOfTrackInfo = cat062DataItems.TimeOfTrackInfo;

        Assert.That(timeOfTrackInfo.Name, Is.EqualTo("I062/070, Time Of Track Information"));
        Assert.That(timeOfTrackInfo.IsMandatory, Is.True);
        Assert.That(timeOfTrackInfo.TimeOfTrackInSecond, Is.EqualTo(46120.9453125).Within(0.0000001));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckPositionInWgs84()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var positionInWgs84 = cat062DataItems.PositionInWgs84;
        
        Assert.That(positionInWgs84.Name, Is.EqualTo("I062/105, Calculated Position In WGS-84 Co-ordinates"));
        Assert.That(positionInWgs84.IsMandatory, Is.False);
        Assert.That(positionInWgs84.Latitude, Is.EqualTo(51.5911853313446).Within(0.0000000001));
        Assert.That(positionInWgs84.Longitude, Is.EqualTo(1.14611327648163).Within(0.0000000001));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckPositionInCartesian()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var positionInCartesian = cat062DataItems.PositionInCartesian;
        
        Assert.That(positionInCartesian.Name, Is.EqualTo("I062/100, Calculated Track Position. (Cartesian)"));
        Assert.That(positionInCartesian.IsMandatory, Is.False);
        Assert.That(positionInCartesian.X, Is.EqualTo(4747.5));
        Assert.That(positionInCartesian.Y, Is.EqualTo(-4519.5));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackVelocityInCartesian()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var velocityInCartesian = cat062DataItems.TrackVelocityInCartesian;
        
        Assert.That(velocityInCartesian.Name, Is.EqualTo("I062/185, Calculated Track Velocity (Cartesian)"));
        Assert.That(velocityInCartesian.IsMandatory, Is.False);
        Assert.That(velocityInCartesian.Vx, Is.EqualTo(-4.5));
        Assert.That(velocityInCartesian.Vy, Is.EqualTo(1.5));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTargetIdentification()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var targetIdentification = cat062DataItems.TargetIdentification;
        
        Assert.That(targetIdentification.Name, Is.EqualTo("I062/245, Target Identification"));
        Assert.That(targetIdentification.IsMandatory, Is.False);
        Assert.That(targetIdentification.Sti, Is.EqualTo(I062245TargetIdentification.StiType.CallsignOrRegistrationDownlinkedFromTarget));
        Assert.That(targetIdentification.CallSign, Is.EqualTo("BOAT 3"));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckAircraftDerivedData()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var aircraftDerivedData = cat062DataItems.AircraftDerivedData;
        
        Assert.That(aircraftDerivedData.Name, Is.EqualTo("I062/380, Aircraft Derived Data"));
        Assert.That(aircraftDerivedData.IsMandatory, Is.False);
        
        Assert.That(aircraftDerivedData.HasAdr, Is.True);
        Assert.That(aircraftDerivedData.TargetAddress, Is.Not.Null);
        Assert.That(aircraftDerivedData.TargetAddress.Name, Is.EqualTo("I062/380, Target Address"));
        Assert.That(aircraftDerivedData.TargetAddress.IsMandatory, Is.False);
        Assert.That(aircraftDerivedData.TargetAddress.TargetAddress, Is.EqualTo(0));
        
        Assert.That(aircraftDerivedData.HasId, Is.True);
        Assert.That(aircraftDerivedData.TargetIdentification, Is.Not.Null);
        Assert.That(aircraftDerivedData.TargetIdentification.Name, Is.EqualTo("I062/380, Target Identification"));
        Assert.That(aircraftDerivedData.TargetIdentification.IsMandatory, Is.False);
        Assert.That(aircraftDerivedData.TargetIdentification.TargetIdentification, Is.EqualTo("BOAT 3"));
        
        Assert.That(aircraftDerivedData.HasBps, Is.False);
        Assert.That(aircraftDerivedData.BarometricPressureSetting, Is.Null);
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackNumber()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackNumber = cat062DataItems.TrackNumber;
        
        Assert.That(trackNumber.Name, Is.EqualTo("I062/040, Track Number"));
        Assert.That(trackNumber.IsMandatory, Is.True);
        Assert.That(trackNumber.TrackNumber, Is.EqualTo(3));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackStatus()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackStatus = cat062DataItems.TrackStatus;
        
        Assert.That(trackStatus.Name, Is.EqualTo("I062/080, Track Status"));
        Assert.That(trackStatus.IsMandatory, Is.True);
        
        Assert.That(trackStatus.IsMonoSensorTrack, Is.False);
        Assert.That(trackStatus.IsSpiPresent, Is.False);
        Assert.That(trackStatus.IsGeoAltitudeMoreReliable, Is.True);
        Assert.That(trackStatus.SourceOfCalculatedTrack, Is.EqualTo(I062080TrackStatus.SourceTrackTypes.NoSource));
        Assert.That(trackStatus.IsTentativeTrack, Is.False);
        Assert.That(trackStatus.Fx1, Is.True);
        
        Assert.That(trackStatus.IsActualTrack, Is.False);
        Assert.That(trackStatus.IsTse, Is.False);
        Assert.That(trackStatus.IsTsb, Is.False);
        Assert.That(trackStatus.IsFlightPlanCorrelated, Is.False);
        Assert.That(trackStatus.IsAff, Is.False);
        Assert.That(trackStatus.IsSlaveTrackPromotion, Is.False);
        Assert.That(trackStatus.IsBackgroundServiceUsed, Is.False);
        Assert.That(trackStatus.Fx2, Is.True);
        
        Assert.That(trackStatus.IsAmalgamation, Is.False);
        Assert.That(trackStatus.Mode4Interrogation, Is.EqualTo(I062080TrackStatus.Mode4InterrogationTypes.NoMode4Interrogation));
        Assert.That(trackStatus.IsMilitaryEmergency, Is.False);
        Assert.That(trackStatus.IsMilitaryIdentification, Is.False);
        Assert.That(trackStatus.Mode5Interrogation, Is.EqualTo(I062080TrackStatus.Mode5InterrogationTypes.NoMode5Interrogation));
        Assert.That(trackStatus.Fx3, Is.True);
        
        Assert.That(trackStatus.IsCst, Is.False);
        Assert.That(trackStatus.IsPsr, Is.False);
        Assert.That(trackStatus.IsSsr, Is.False);
        Assert.That(trackStatus.IsMds, Is.False);
        Assert.That(trackStatus.IsAds, Is.False);
        Assert.That(trackStatus.IsSuc, Is.False);
        Assert.That(trackStatus.IsAac, Is.False);
        Assert.That(trackStatus.Fx4, Is.False);
        
        Assert.That(trackStatus.SurveillanceDataStatus, Is.EqualTo(I062080TrackStatus.SurveillanceStatusTypes.NotDefined));
        Assert.That(trackStatus.EmergencyStatusIndication, Is.EqualTo(I062080TrackStatus.EmergencyStatusTypes.Undefined));
        Assert.That(trackStatus.IsPotentialFalseTrackIndication, Is.False);
        Assert.That(trackStatus.IsTrackWithFplData, Is.False);
        Assert.That(trackStatus.Fx5, Is.False);
        
        Assert.That(trackStatus.IsDuplicateMode3ACode, Is.False);
        Assert.That(trackStatus.IsDuplicateFlightPlan, Is.False);
        Assert.That(trackStatus.IsDuplicateFlightPlanDueToManualCorrelation, Is.False);
        Assert.That(trackStatus.SurfaceTarget, Is.False);
        Assert.That(trackStatus.IsDuplicateFlightId, Is.False);
        Assert.That(trackStatus.IsInconsistentEmergencyCode, Is.False);
        Assert.That(trackStatus.IsMlat, Is.False);
        Assert.That(trackStatus.Fx6, Is.False);
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackGeometricAltitude()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackGeometricAltitude = cat062DataItems.TrackGeometricAltitude;

        Assert.That(trackGeometricAltitude.Name, Is.EqualTo("I062/130, Calculated Track Geometric Altitude"));
        Assert.That(trackGeometricAltitude.IsMandatory, Is.False);
        Assert.That(trackGeometricAltitude.CalculatedTrackGeometricAltitude, Is.EqualTo(0));
    }
    
    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckMeasuredInformation()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var measuredInformation = cat062DataItems.MeasuredInformation;

        Assert.That(measuredInformation.Name, Is.EqualTo("I062/340, Measured Information"));
        Assert.That(measuredInformation.IsMandatory, Is.False);
        
        Assert.That(measuredInformation.HasPos, Is.True);
        Assert.That(measuredInformation.MeasuredPosition, Is.Not.Null);
        Assert.That(measuredInformation.MeasuredPosition.Name, Is.EqualTo("I062/340, Measured Position"));
        Assert.That(measuredInformation.MeasuredPosition.IsMandatory, Is.False);
        Assert.That(measuredInformation.MeasuredPosition.Rho, Is.EqualTo(3.5390625).Within(0.0000001));
        Assert.That(measuredInformation.MeasuredPosition.Theta, Is.EqualTo(133.582763671875).Within(0.00000000001));
        
        Assert.That(measuredInformation.HasHei, Is.True);
        Assert.That(measuredInformation.HeightInTwoComplement, Is.Not.Null);
        Assert.That(measuredInformation.HeightInTwoComplement.Name, Is.EqualTo("I062/340, Measured 3-D Height in Two’s Complement"));
        Assert.That(measuredInformation.HeightInTwoComplement.IsMandatory, Is.False);
        Assert.That(measuredInformation.HeightInTwoComplement.Measured3dHeight, Is.EqualTo(0));
        
        Assert.That(measuredInformation.HasTyp, Is.True);
        Assert.That(measuredInformation.ReportType, Is.Not.Null);
        Assert.That(measuredInformation.ReportType.Name, Is.EqualTo("I062/340, Report Type"));
        Assert.That(measuredInformation.ReportType.IsMandatory, Is.False);
        Assert.That(measuredInformation.ReportType.Type, Is.EqualTo(I062340Sf6ReportType.ReportTypes.SsrPsrDetection));
        Assert.That(measuredInformation.ReportType.IsSimulatedTargetReport, Is.False);
        Assert.That(measuredInformation.ReportType.IsTestTargetReport, Is.False);
        Assert.That(measuredInformation.ReportType.IsReportFromFieldMonitor, Is.False);
        
        Assert.That(measuredInformation.HasMda, Is.False);
    }
}