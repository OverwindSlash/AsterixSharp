using Cat062PacketParser;
using Cat062PacketParser.DataItems;

namespace Cat062HeaderTests;

public class Cat062DataItemsTestAll_1
{
    private byte[] _buffer;

    private byte[] LoadCambridgePixelSimulatorData()
    {
        return File.ReadAllBytes("data/cat062-all-1.bin"); 
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);
        
        Assert.That(cat062DataItems.SourceIdentifier, Is.Not.Null);
        Assert.That(cat062DataItems.ServiceIdentification, Is.Not.Null);
        Assert.That(cat062DataItems.TimeOfTrackInfo, Is.Not.Null);
        Assert.That(cat062DataItems.PositionInWgs84, Is.Not.Null);
        Assert.That(cat062DataItems.PositionInCartesian, Is.Not.Null);
        Assert.That(cat062DataItems.TrackVelocityInCartesian, Is.Not.Null);
        Assert.That(cat062DataItems.AccelerationInCartesian, Is.Not.Null);
        
        Assert.That(cat062DataItems.TrackMode3ACode, Is.Not.Null);
        Assert.That(cat062DataItems.TrackNumber, Is.Not.Null);
        Assert.That(cat062DataItems.TrackStatus, Is.Not.Null);
        Assert.That(cat062DataItems.SystemTrackUpdateAges, Is.Not.Null);
        Assert.That(cat062DataItems.ModeOfMovement, Is.Not.Null);
        Assert.That(cat062DataItems.TrackDataAges, Is.Not.Null);
        Assert.That(cat062DataItems.MeasuredFlightLevel, Is.Not.Null);
        
        Assert.That(cat062DataItems.TrackGeometricAltitude, Is.Not.Null);
        Assert.That(cat062DataItems.TrackBarometricAltitude, Is.Not.Null);
        Assert.That(cat062DataItems.RateOfClimbDescent, Is.Not.Null);
        Assert.That(cat062DataItems.TrackMode2Code, Is.Not.Null);
        Assert.That(cat062DataItems.ComposedTrackNumber, Is.Not.Null);
        Assert.That(cat062DataItems.EstimatedAccuracies, Is.Not.Null);
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
        Assert.That(sourceIdentifier.SystemAreaCode, Is.EqualTo(52));
        Assert.That(sourceIdentifier.SystemIdentificationCode, Is.EqualTo(209));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckServiceIdentification()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var serviceIdentification = cat062DataItems.ServiceIdentification;

        Assert.That(serviceIdentification.Name, Is.EqualTo("I062/015, Service Identification"));
        Assert.That(serviceIdentification.IsMandatory, Is.False);
        Assert.That(serviceIdentification.ServiceIdentification, Is.EqualTo(13));
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
        Assert.That(timeOfTrackInfo.TimeOfTrackInSecond, Is.EqualTo(34808.171875).Within(0.0000001));
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
        Assert.That(positionInWgs84.Latitude, Is.EqualTo(49.1813331842422).Within(0.0000000001));
        Assert.That(positionInWgs84.Longitude, Is.EqualTo(2.07998871803284).Within(0.0000000001));
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
        Assert.That(positionInCartesian.X, Is.EqualTo(261930.5));
        Assert.That(positionInCartesian.Y, Is.EqualTo(-315025));
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
        Assert.That(velocityInCartesian.Vx, Is.EqualTo(-56));
        Assert.That(velocityInCartesian.Vy, Is.EqualTo(146.75));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckAccelerationInCartesian()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var accelerationInCartesian = cat062DataItems.AccelerationInCartesian;

        Assert.That(accelerationInCartesian.Name, Is.EqualTo("I062/210, Calculated Acceleration (Cartesian)"));
        Assert.That(accelerationInCartesian.IsMandatory, Is.False);
        Assert.That(accelerationInCartesian.Ax, Is.EqualTo(0));
        Assert.That(accelerationInCartesian.Ay, Is.EqualTo(0));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackMode3ACode()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackMode3ACode = cat062DataItems.TrackMode3ACode;

        Assert.That(trackMode3ACode.Name, Is.EqualTo("I062/060, Track Mode 3/A Code"));
        Assert.That(trackMode3ACode.IsMandatory, Is.False);
        Assert.That(trackMode3ACode.IsCodeNotValidated, Is.False);
        Assert.That(trackMode3ACode.IsGarbledCode, Is.False);
        Assert.That(trackMode3ACode.HasChanged, Is.False);
        Assert.That(trackMode3ACode.ReplyA4, Is.True);
        Assert.That(trackMode3ACode.ReplyA2, Is.False);
        Assert.That(trackMode3ACode.ReplyA1, Is.True);
        Assert.That(trackMode3ACode.ReplyB4, Is.True);
        Assert.That(trackMode3ACode.ReplyB2, Is.True);
        Assert.That(trackMode3ACode.ReplyB1, Is.False);
        Assert.That(trackMode3ACode.ReplyC4, Is.False);
        Assert.That(trackMode3ACode.ReplyC2, Is.False);
        Assert.That(trackMode3ACode.ReplyC1, Is.False);
        Assert.That(trackMode3ACode.ReplyD4, Is.False);
        Assert.That(trackMode3ACode.ReplyD2, Is.True);
        Assert.That(trackMode3ACode.ReplyD1, Is.False);
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
        Assert.That(trackNumber.TrackNumber, Is.EqualTo(4542));
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

        Assert.That(trackStatus.IsMonoSensorTrack, Is.True);
        Assert.That(trackStatus.IsSpiPresent, Is.False);
        Assert.That(trackStatus.IsGeoAltitudeMoreReliable, Is.False);
        Assert.That(trackStatus.SourceOfCalculatedTrack, Is.EqualTo(I062080TrackStatus.SourceTrackTypes.DefaultHeight));
        Assert.That(trackStatus.IsTentativeTrack, Is.False);
        Assert.That(trackStatus.Fx1, Is.True);

        Assert.That(trackStatus.IsActualTrack, Is.False);
        Assert.That(trackStatus.IsTse, Is.False);
        Assert.That(trackStatus.IsTsb, Is.True);
        Assert.That(trackStatus.IsFlightPlanCorrelated, Is.False);
        Assert.That(trackStatus.IsAff, Is.False);
        Assert.That(trackStatus.IsSlaveTrackPromotion, Is.False);
        Assert.That(trackStatus.IsBackgroundServiceUsed, Is.True);
        Assert.That(trackStatus.Fx2, Is.True);

        Assert.That(trackStatus.IsAmalgamation, Is.False);
        Assert.That(trackStatus.Mode4Interrogation, Is.EqualTo(I062080TrackStatus.Mode4InterrogationTypes.NoMode4Interrogation));
        Assert.That(trackStatus.IsMilitaryEmergency, Is.False);
        Assert.That(trackStatus.IsMilitaryIdentification, Is.False);
        Assert.That(trackStatus.Mode5Interrogation, Is.EqualTo(I062080TrackStatus.Mode5InterrogationTypes.NoMode5Interrogation));
        Assert.That(trackStatus.Fx3, Is.True);

        Assert.That(trackStatus.IsCst, Is.False);
        Assert.That(trackStatus.IsPsr, Is.True);
        Assert.That(trackStatus.IsSsr, Is.False);
        Assert.That(trackStatus.IsMds, Is.True);
        Assert.That(trackStatus.IsAds, Is.True);
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
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckSystemTrackUpdateAges()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackUpdateAges = cat062DataItems.SystemTrackUpdateAges;

        Assert.That(trackUpdateAges.Name, Is.EqualTo("I062/290, System Track Update Ages"));
        Assert.That(trackUpdateAges.IsMandatory, Is.False);
        Assert.That(trackUpdateAges.PsrAge.Psr, Is.EqualTo(63.75));
        Assert.That(trackUpdateAges.SsrAge.Ssr, Is.EqualTo(6.5));
        Assert.That(trackUpdateAges.ModeSAge.ModeS, Is.EqualTo(63.75));
        Assert.That(trackUpdateAges.AdscAge.Ads, Is.EqualTo(16383.75));
        Assert.That(trackUpdateAges.EsAge.Es, Is.EqualTo(63.75));
        Assert.That(trackUpdateAges.VdlAge.Vdl, Is.EqualTo(63.75));
        Assert.That(trackUpdateAges.UatAge.Uat, Is.EqualTo(63.75));
        Assert.That(trackUpdateAges.MultilaterationAge.Mlt, Is.EqualTo(63.75));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckModeOfMovement()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var modeOfMovement = cat062DataItems.ModeOfMovement;

        Assert.That(modeOfMovement.Name, Is.EqualTo("I062/200, Mode of Movement"));
        Assert.That(modeOfMovement.IsMandatory, Is.False);

        Assert.That(modeOfMovement.Trans, Is.EqualTo(I062200ModeOfMovement.TransTypes.ConstantCourse));
        Assert.That(modeOfMovement.Long, Is.EqualTo(I062200ModeOfMovement.LongTypes.ConstantGroundspeed));
        Assert.That(modeOfMovement.Vert, Is.EqualTo(I062200ModeOfMovement.VertTypes.Climb));
        Assert.That(modeOfMovement.Adf, Is.EqualTo(I062200ModeOfMovement.AdfTypes.NoAltitudeDiscrepancy));
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
        Assert.That(measuredInformation.MeasuredPosition.Rho, Is.EqualTo(3.5390625).Within(0.0000001));
        Assert.That(measuredInformation.MeasuredPosition.Theta, Is.EqualTo(133.582763671875).Within(0.00000000001));
        
        Assert.That(measuredInformation.HasHei, Is.True);
        
        Assert.That(measuredInformation.HasTyp, Is.True);
        
        Assert.That(measuredInformation.HasMda, Is.False);

    }
}