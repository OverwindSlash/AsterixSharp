using Cat062PacketParser;
using Cat062PacketParser.DataItems;
using Cat062PacketParser.DataItems.SubFields.I062380;

namespace Cat062DataItemsTests;

public class Cat062DataItemsTestAll_2
{
    private byte[] _buffer;

    private byte[] LoadCambridgePixelSimulatorData()
    {
        return File.ReadAllBytes("data/cat062-all-2.bin"); 
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
        Assert.That(cat062DataItems.AircraftDerivedData, Is.Not.Null);
        Assert.That(cat062DataItems.TrackNumber, Is.Not.Null);
        Assert.That(cat062DataItems.TrackStatus, Is.Not.Null);
        Assert.That(cat062DataItems.SystemTrackUpdateAges, Is.Not.Null);
        Assert.That(cat062DataItems.ModeOfMovement, Is.Not.Null);
        Assert.That(cat062DataItems.TrackDataAges, Is.Not.Null);
        Assert.That(cat062DataItems.MeasuredFlightLevel, Is.Not.Null);
        
        Assert.That(cat062DataItems.TrackGeometricAltitude, Is.Not.Null);
        Assert.That(cat062DataItems.TrackBarometricAltitude, Is.Not.Null);
        Assert.That(cat062DataItems.RateOfClimbDescent, Is.Not.Null);
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
        Assert.That(positionInWgs84.Latitude, Is.EqualTo(52.7982866764069).Within(0.0000000001));
        Assert.That(positionInWgs84.Longitude, Is.EqualTo(2.49170780181885).Within(0.0000000001));
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
        Assert.That(positionInCartesian.X, Is.EqualTo(269920.5));
        Assert.That(positionInCartesian.Y, Is.EqualTo(88550));
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
        Assert.That(velocityInCartesian.Vx, Is.EqualTo(275.25));
        Assert.That(velocityInCartesian.Vy, Is.EqualTo(-57));
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
        Assert.That(trackMode3ACode.ReplyA4, Is.False);
        Assert.That(trackMode3ACode.ReplyA2, Is.True);
        Assert.That(trackMode3ACode.ReplyA1, Is.True);
        Assert.That(trackMode3ACode.ReplyB4, Is.True);
        Assert.That(trackMode3ACode.ReplyB2, Is.False);
        Assert.That(trackMode3ACode.ReplyB1, Is.False);
        Assert.That(trackMode3ACode.ReplyC4, Is.True);
        Assert.That(trackMode3ACode.ReplyC2, Is.False);
        Assert.That(trackMode3ACode.ReplyC1, Is.False);
        Assert.That(trackMode3ACode.ReplyD4, Is.True);
        Assert.That(trackMode3ACode.ReplyD2, Is.True);
        Assert.That(trackMode3ACode.ReplyD1, Is.False);
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

        Assert.That(aircraftDerivedData.TargetAddress.TargetAddress, Is.EqualTo(12604406));
        Assert.That(aircraftDerivedData.TargetIdentification.TargetIdentification, Is.EqualTo("ACA844  "));
        Assert.That(aircraftDerivedData.MagneticHeading.MagneticHeading, Is.EqualTo(111.26953125).Within(0.0000001));
        Assert.That(aircraftDerivedData.TrueAirspeed.TrueAirSpeed, Is.EqualTo(448));
        Assert.That(aircraftDerivedData.FinalStateSelectedAltitude.IsManageVerticalModeActive, Is.False);
        Assert.That(aircraftDerivedData.FinalStateSelectedAltitude.IsAltitudeHoldActive, Is.False);
        Assert.That(aircraftDerivedData.FinalStateSelectedAltitude.IsApproachModeActive, Is.False);
        Assert.That(aircraftDerivedData.FinalStateSelectedAltitude.Altitude, Is.EqualTo(39000));
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.CommCapability, Is.EqualTo(I062380Sf10CommAcasFlightStatus.CommCapabilityTypes.CommAAndCommB));
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.FlightStatus, Is.EqualTo(I062380Sf10CommAcasFlightStatus.FlightStatusTypes.NoAlertNoSpiAircraftAirborne));
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.IsSpecificServiceCapability, Is.True);
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.IsAltitudeReportingCapability, Is.True);
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.IsAircraftIdentificationCapability, Is.True);
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.B1A, Is.True);
        Assert.That(aircraftDerivedData.CommAcasFlightStatus.B1B, Is.EqualTo(6));
        Assert.That(aircraftDerivedData.BarometricVerticalRate.Bvr, Is.EqualTo(-318.75));
        Assert.That(aircraftDerivedData.GeometricVerticalRate.Gvr, Is.EqualTo(-62.5));
        Assert.That(aircraftDerivedData.RollAngle.Ran, Is.EqualTo(14.41));
        Assert.That(aircraftDerivedData.TrackAngleRate.TurnIndicator, Is.EqualTo(I062380Sf16TrackAngleRate.TurnIndicatorTypes.NotAvailable));
        Assert.That(aircraftDerivedData.TrackAngleRate.RateOfTurn, Is.EqualTo(0.5));
        Assert.That(aircraftDerivedData.TrackAngle.Tan, Is.EqualTo(103.53515625));
        Assert.That(aircraftDerivedData.GroundSpeed.Gsp, Is.EqualTo(0.151123046875));
        Assert.That(aircraftDerivedData.IndicatedAirspeedSubField.Ias, Is.EqualTo(247));
        Assert.That(aircraftDerivedData.MachNumber.Mac, Is.EqualTo(0.8));
        Assert.That(aircraftDerivedData.BarometricPressureSetting.Bps, Is.EqualTo(225));
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
        Assert.That(trackNumber.TrackNumber, Is.EqualTo(4322));
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
        Assert.That(trackStatus.IsGeoAltitudeMoreReliable, Is.False);
        Assert.That(trackStatus.SourceOfCalculatedTrack, Is.EqualTo(I062080TrackStatus.SourceTrackTypes.Triangulation));
        Assert.That(trackStatus.IsTentativeTrack, Is.False);
        Assert.That(trackStatus.Fx1, Is.True);

        Assert.That(trackStatus.IsActualTrack, Is.False);
        Assert.That(trackStatus.IsTse, Is.False);
        Assert.That(trackStatus.IsTsb, Is.False);
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
        Assert.That(trackStatus.IsPsr, Is.False);
        Assert.That(trackStatus.IsSsr, Is.False);
        Assert.That(trackStatus.IsMds, Is.False);
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
        Assert.That(trackUpdateAges.PsrAge.Psr, Is.EqualTo(2.5));
        Assert.That(trackUpdateAges.SsrAge.Ssr, Is.EqualTo(2.5));
        Assert.That(trackUpdateAges.ModeSAge.ModeS, Is.EqualTo(2.5));
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
        Assert.That(modeOfMovement.Vert, Is.EqualTo(I062200ModeOfMovement.VertTypes.Level));
        Assert.That(modeOfMovement.Adf, Is.EqualTo(I062200ModeOfMovement.AdfTypes.NoAltitudeDiscrepancy));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackDataAges()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackDataAges = cat062DataItems.TrackDataAges;

        Assert.That(trackDataAges.Name, Is.EqualTo("I062/295, Track Data Ages"));
        Assert.That(trackDataAges.IsMandatory, Is.False);

        Assert.That(trackDataAges.Mfl.Mfl, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Mda.Mda, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Mhg.Mhg, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Tas.Tas, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Fss.Fss, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Com.Com, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Bvr.Bvr, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Gvr.Gvr, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Ran.Ran, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Tar.Tar, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Tan.Tan, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Gsp.Gsp, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Iar.Iar, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Mac.Mac, Is.EqualTo(2.5));
        Assert.That(trackDataAges.Bps.Bps, Is.EqualTo(2.5));

        Assert.That(trackDataAges.Md2, Is.Null);
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckMeasuredFlightLevel()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var measuredFlightLevel = cat062DataItems.MeasuredFlightLevel;

        Assert.That(measuredFlightLevel.Name, Is.EqualTo("I062/136, Measured Flight Level"));
        Assert.That(measuredFlightLevel.IsMandatory, Is.False);

        Assert.That(measuredFlightLevel.MeasuredFlightLevel, Is.EqualTo(389.75));
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
        Assert.That(trackGeometricAltitude.CalculatedTrackGeometricAltitude, Is.EqualTo(37956.25));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckTrackBarometricAltitude()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackBarometricAltitude = cat062DataItems.TrackBarometricAltitude;

        Assert.That(trackBarometricAltitude.Name, Is.EqualTo("I062/135, Calculated Track Barometric Altitude"));
        Assert.That(trackBarometricAltitude.IsMandatory, Is.False);
        Assert.That(trackBarometricAltitude.IsQnhCorrectionApplied, Is.False);
        Assert.That(trackBarometricAltitude.CalculatedTrackBarometricAltitude, Is.EqualTo(390));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckRateOfClimbDescent()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var rateOfClimbDescent = cat062DataItems.RateOfClimbDescent;

        Assert.That(rateOfClimbDescent.Name, Is.EqualTo("I062/220, Calculated Rate Of Climb/Descent"));
        Assert.That(rateOfClimbDescent.IsMandatory, Is.False);
        Assert.That(rateOfClimbDescent.RateOfClimbDescent, Is.EqualTo(0));
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckComposedTrackNumber()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var trackNumber = cat062DataItems.ComposedTrackNumber;

        Assert.That(trackNumber.Name, Is.EqualTo("I062/510, Composed Track Number"));
        Assert.That(trackNumber.IsMandatory, Is.False);

        Assert.That(trackNumber.SystemUnitIdentification, Is.EqualTo(11));
        Assert.That(trackNumber.SystemTrackNumber, Is.EqualTo(226));
        Assert.That(trackNumber.Fx, Is.False);
    }

    [Test]
    public void TestGenerateCat062DataItemsWithCambridgePixelSimulatorData_CheckEstimatedAccuracies()
    {
        _buffer = LoadCambridgePixelSimulatorData();

        var cat062Header = new Cat062Header(_buffer);
        var cat062DataItems = new Cat062DataItems(cat062Header, _buffer, cat062Header.DataBlockLength);

        var estimatedAccuracies = cat062DataItems.EstimatedAccuracies;

        Assert.That(estimatedAccuracies.Name, Is.EqualTo("I062/500, Estimated Accuracies"));
        Assert.That(estimatedAccuracies.IsMandatory, Is.False);

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackPositionInCartesian.ApcXComponent, Is.EqualTo(62.5));
        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackPositionInCartesian.ApcYComponent, Is.EqualTo(55));

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackPositionInWgs84.ApwLatitude, Is.EqualTo(0.000493526458740234).Within(0.0000000001));
        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackPositionInWgs84.ApwLongitude, Is.EqualTo(0.000928044319152832).Within(0.0000000001));

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfCalculatedTrackGeometricAltitude.Aga, Is.EqualTo(1593.75));
        Assert.That(estimatedAccuracies.EstimatedAccuracyOfCalculatedTrackBarometricAltitude.Aba, Is.EqualTo(0.25));

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackVelocityInCartesian.AtvXComponent, Is.EqualTo(4.25));
        Assert.That(estimatedAccuracies.EstimatedAccuracyOfTrackVelocityInCartesian.AtvYComponent, Is.EqualTo(4.5));

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfAccelerationInCartesian.AaXComponent, Is.EqualTo(0));
        Assert.That(estimatedAccuracies.EstimatedAccuracyOfAccelerationInCartesian.AaYComponent, Is.EqualTo(0.5));

        Assert.That(estimatedAccuracies.EstimatedAccuracyOfRateOfClimbDescent.Arc, Is.EqualTo(137.5));
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
        
        Assert.That(measuredInformation.HasSid, Is.True);
        Assert.That(measuredInformation.SensorIdentification, Is.Not.Null);
        Assert.That(measuredInformation.SensorIdentification.SystemAreaCode, Is.EqualTo(52));
        Assert.That(measuredInformation.SensorIdentification.SystemIdentificationCode, Is.EqualTo(49));

        Assert.That(measuredInformation.HasPos, Is.True);
        Assert.That(measuredInformation.MeasuredPosition, Is.Not.Null);
        Assert.That(measuredInformation.MeasuredPosition.Rho, Is.EqualTo(143.91796875));
        Assert.That(measuredInformation.MeasuredPosition.Theta, Is.EqualTo(43.08837890625));

        Assert.That(measuredInformation.HasMdc, Is.True);
        Assert.That(measuredInformation.LastMeasuredModeCCode, Is.Not.Null);
        Assert.That(measuredInformation.LastMeasuredModeCCode.IsCodeNotValidated, Is.False);
        Assert.That(measuredInformation.LastMeasuredModeCCode.IsGarbledCode, Is.False);
        Assert.That(measuredInformation.LastMeasuredModeCCode.Mdc, Is.EqualTo(389.75));

        Assert.That(measuredInformation.HasMda, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode, Is.Not.Null);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.IsCodeNotValidated, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.IsGarbledCode, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.IsSmoothedMode3ACode, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyA4, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyA2, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyA1, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyB4, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyB2, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyB1, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyC4, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyC2, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyC1, Is.False);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyD4, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyD2, Is.True);
        Assert.That(measuredInformation.LastMeasuredMode3ACode.ReplyD1, Is.False);
    }
}