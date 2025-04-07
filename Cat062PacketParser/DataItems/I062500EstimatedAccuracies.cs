using AsterixCore;
using Cat062PacketParser.DataItems.SubFields.I062500;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062500EstimatedAccuracies : ExtentableDataItemWithSubFields
{
    public const int MaxEstimatedAccuraciesSubFieldFlagLength = 2;
    
    #region PrimarySubfield
    public bool HasApc { get; private set; }
    public bool HasCov { get; private set; }
    public bool HasApw { get; private set; }
    public bool HasAga { get; private set; }
    public bool HasAba { get; private set; }
    public bool HasAtv { get; private set; }
    public bool HasAa { get; private set; }
    public bool Fx1 { get; private set; }

    public bool HasArc { get; private set; }
    public bool Fx2 { get; private set; }
    #endregion
    
    #region Subfield Items
    public I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian EstimatedAccuracyOfTrackPositionInCartesian { get; private set; }
    public I062500Sf2XYCovarianceComponent XyCovarianceComponent { get; private set; }
    public I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84 EstimatedAccuracyOfTrackPositionInWgs84 { get; private set; }
    public I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude EstimatedAccuracyOfCalculatedTrackGeometricAltitude { get; private set; }
    public I062500Sf5EstimatedAccuracyOfCalculatedTrackBarometricAltitude EstimatedAccuracyOfCalculatedTrackBarometricAltitude { get; private set; }
    public I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian EstimatedAccuracyOfTrackVelocityInCartesian { get; private set; }
    public I062500Sf7EstimatedAccuracyOfAccelerationInCartesian EstimatedAccuracyOfAccelerationInCartesian { get; private set; }
    public I062500Sf8EstimatedAccuracyOfRateOfClimbDescent EstimatedAccuracyOfRateOfClimbDescent { get; private set; }
    #endregion

    public I062500EstimatedAccuracies(byte[] buffer, int offset)
    {
        Name = "I062/500, Estimated Accuracies";
        IsMandatory = false;
        
        ParseExtentableData(MaxEstimatedAccuraciesSubFieldFlagLength, buffer, offset);
        offset += Length;

        ExtractSubFieldFlag();
        
        ParseSubFields(buffer, offset);
    }

    private void ExtractSubFieldFlag()
    {
        HasApc = BitOperations.GetBit(RawData, 0);
        HasCov = BitOperations.GetBit(RawData, 1);
        HasApw = BitOperations.GetBit(RawData, 2);
        HasAga = BitOperations.GetBit(RawData, 3);
        HasAba = BitOperations.GetBit(RawData, 4);
        HasAtv = BitOperations.GetBit(RawData, 5);
        HasAa = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        HasArc = BitOperations.GetBit(RawData, 8);
        // BitOperations.GetBit(RawData, 9);    // Spare
        // BitOperations.GetBit(RawData, 10);   // Spare
        // BitOperations.GetBit(RawData, 11);   // Spare
        // BitOperations.GetBit(RawData, 12);   // Spare
        // BitOperations.GetBit(RawData, 13);   // Spare
        // BitOperations.GetBit(RawData, 14);   // Spare
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasApc)
        {
            EstimatedAccuracyOfTrackPositionInCartesian = new I062500Sf1EstimatedAccuracyOfTrackPositionInCartesian(buffer, offset);
            offset += EstimatedAccuracyOfTrackPositionInCartesian.Length;
            Length += EstimatedAccuracyOfTrackPositionInCartesian.Length;
        }

        if (HasCov)
        {
            XyCovarianceComponent = new I062500Sf2XYCovarianceComponent(buffer, offset);
            offset += XyCovarianceComponent.Length;
            Length += XyCovarianceComponent.Length;
        }

        if (HasApw)
        {
            EstimatedAccuracyOfTrackPositionInWgs84 = new I062500Sf3EstimatedAccuracyOfTrackPositionInWgs84(buffer, offset);
            offset += EstimatedAccuracyOfTrackPositionInWgs84.Length;
            Length += EstimatedAccuracyOfTrackPositionInWgs84.Length;
        }

        if (HasAga)
        {
            EstimatedAccuracyOfCalculatedTrackGeometricAltitude = new I062500Sf4EstimatedAccuracyOfCalculatedTrackGeometricAltitude(buffer, offset);
            offset += EstimatedAccuracyOfCalculatedTrackGeometricAltitude.Length;
            Length += EstimatedAccuracyOfCalculatedTrackGeometricAltitude.Length;
        }

        if (HasAba)
        {
            EstimatedAccuracyOfCalculatedTrackBarometricAltitude = new I062500Sf5EstimatedAccuracyOfCalculatedTrackBarometricAltitude(buffer, offset);
            offset += EstimatedAccuracyOfCalculatedTrackBarometricAltitude.Length;
            Length += EstimatedAccuracyOfCalculatedTrackBarometricAltitude.Length;
        }

        if (HasAtv)
        {
            EstimatedAccuracyOfTrackVelocityInCartesian = new I062500Sf6EstimatedAccuracyOfTrackVelocityInCartesian(buffer, offset);
            offset += EstimatedAccuracyOfTrackVelocityInCartesian.Length;
            Length += EstimatedAccuracyOfTrackVelocityInCartesian.Length;
        }

        if (HasAa)
        {
            EstimatedAccuracyOfAccelerationInCartesian = new I062500Sf7EstimatedAccuracyOfAccelerationInCartesian(buffer, offset);
            offset += EstimatedAccuracyOfAccelerationInCartesian.Length;
            Length += EstimatedAccuracyOfAccelerationInCartesian.Length;
        }

        if (HasArc)
        {
            EstimatedAccuracyOfRateOfClimbDescent = new I062500Sf8EstimatedAccuracyOfRateOfClimbDescent(buffer, offset);
            offset += EstimatedAccuracyOfRateOfClimbDescent.Length;
            Length += EstimatedAccuracyOfRateOfClimbDescent.Length;
        }
    }
}