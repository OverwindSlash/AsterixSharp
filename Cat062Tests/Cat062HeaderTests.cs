using Cat062PacketParser;

namespace Cat062HeaderTests;

public class Cat062HeaderTests
{
    private byte[] _buffer;

    private byte[] LoadCambridgePixelSimulatorData()
    {
        return File.ReadAllBytes("data/cat062.bin"); 
    }

    private byte[] LoadNantongData()
    {
        return File.ReadAllBytes("data/sa_test_1.bin"); 
    }

    [Test]
    public void TestGenerateCat062HeaderWithCambridgePixelSimulatorData()
    {
        _buffer = LoadCambridgePixelSimulatorData();
        
        var cat062Header = new Cat062Header(_buffer);
        
        Assert.That(cat062Header.HasDataSourceIdentifier, Is.True);
        Assert.That(cat062Header.HasServiceIdentification, Is.False);
        Assert.That(cat062Header.HasTimeOfTrackInformation, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackPositionWgs84, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackPositionCartesian, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackVelocityCartesian, Is.True);
        Assert.That(cat062Header.Fx1, Is.True);
        
        Assert.That(cat062Header.HasCalculatedAccelerationCartesian, Is.False);
        Assert.That(cat062Header.HasTrackMode3ACode, Is.False);
        Assert.That(cat062Header.HasTargetIdentification, Is.True);
        Assert.That(cat062Header.HasAircraftDerivedData, Is.True);
        Assert.That(cat062Header.HasTrackNumber, Is.True);
        Assert.That(cat062Header.HasTrackStatus, Is.True);
        Assert.That(cat062Header.HasSystemTrackUpdateAges, Is.False);
        Assert.That(cat062Header.Fx2, Is.True);
        
        Assert.That(cat062Header.HasModeOfMovement, Is.False);
        Assert.That(cat062Header.HasTrackDataAges, Is.False);
        Assert.That(cat062Header.HasMeasuredFlightLevel, Is.False);
        Assert.That(cat062Header.HasCalculatedTrackGeometricAltitude, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackBarometricAltitude, Is.False);
        Assert.That(cat062Header.HasCalculatedRateOfClimbDescent, Is.False);
        Assert.That(cat062Header.HasFlightPlanRelatedData, Is.False);
        Assert.That(cat062Header.Fx3, Is.True);
        
        Assert.That(cat062Header.HasTargetSizeAndOrientation, Is.False);
        Assert.That(cat062Header.HasVehicleFleetIdentification, Is.False);
        Assert.That(cat062Header.HasMode5DataReportsAndExtendedMode1Code, Is.False);
        Assert.That(cat062Header.HasTrackMode2Code, Is.False);
        Assert.That(cat062Header.HasComposedTrackNumber, Is.False);
        Assert.That(cat062Header.HasEstimatedAccuracies, Is.False);
        Assert.That(cat062Header.HasMeasuredInformation, Is.True);
        Assert.That(cat062Header.Fx4, Is.True);
        
        Assert.That(cat062Header.HasReservedExpansionField, Is.False);
        Assert.That(cat062Header.HasReservedForSpecialPurposeIndicator, Is.False);
        Assert.That(cat062Header.Fx5, Is.False);
    }

    [Test]
    public void TestGenerateCat062HeaderWithNantongData()
    {
        _buffer = LoadNantongData();
        
        var cat062Header = new Cat062Header(_buffer);
        
        Assert.That(cat062Header.HasDataSourceIdentifier, Is.True);
        Assert.That(cat062Header.HasServiceIdentification, Is.False);
        Assert.That(cat062Header.HasTimeOfTrackInformation, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackPositionWgs84, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackPositionCartesian, Is.False);
        Assert.That(cat062Header.HasCalculatedTrackVelocityCartesian, Is.False);
        Assert.That(cat062Header.Fx1, Is.True);
        
        Assert.That(cat062Header.HasCalculatedAccelerationCartesian, Is.False);
        Assert.That(cat062Header.HasTrackMode3ACode, Is.False);
        Assert.That(cat062Header.HasTargetIdentification, Is.False);
        Assert.That(cat062Header.HasAircraftDerivedData, Is.True);
        Assert.That(cat062Header.HasTrackNumber, Is.True);
        Assert.That(cat062Header.HasTrackStatus, Is.False);
        Assert.That(cat062Header.HasSystemTrackUpdateAges, Is.False);
        Assert.That(cat062Header.Fx2, Is.True);
        
        Assert.That(cat062Header.HasModeOfMovement, Is.False);
        Assert.That(cat062Header.HasTrackDataAges, Is.False);
        Assert.That(cat062Header.HasMeasuredFlightLevel, Is.False);
        Assert.That(cat062Header.HasCalculatedTrackGeometricAltitude, Is.True);
        Assert.That(cat062Header.HasCalculatedTrackBarometricAltitude, Is.False);
        Assert.That(cat062Header.HasCalculatedRateOfClimbDescent, Is.False);
        Assert.That(cat062Header.HasFlightPlanRelatedData, Is.False);
        Assert.That(cat062Header.Fx3, Is.False);
        
        Assert.That(cat062Header.HasTargetSizeAndOrientation, Is.False);
        Assert.That(cat062Header.HasVehicleFleetIdentification, Is.False);
        Assert.That(cat062Header.HasMode5DataReportsAndExtendedMode1Code, Is.False);
        Assert.That(cat062Header.HasTrackMode2Code, Is.False);
        Assert.That(cat062Header.HasComposedTrackNumber, Is.False);
        Assert.That(cat062Header.HasEstimatedAccuracies, Is.False);
        Assert.That(cat062Header.HasMeasuredInformation, Is.False);
        Assert.That(cat062Header.Fx4, Is.False);
        
        Assert.That(cat062Header.HasReservedExpansionField, Is.False);
        Assert.That(cat062Header.HasReservedForSpecialPurposeIndicator, Is.False);
        Assert.That(cat062Header.Fx5, Is.False);
    }
}