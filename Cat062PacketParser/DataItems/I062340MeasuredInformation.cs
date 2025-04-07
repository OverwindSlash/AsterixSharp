using AsterixCore;
using Cat062PacketParser.DataItems.SubFields.I062340;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062340MeasuredInformation : ExtentableDataItemWithSubFields
{
    public const int MaxMeasuredInformationLength = 1;
    
    #region PrimarySubfield
    public bool HasSid { get; private set; }
    public bool HasPos { get; private set; }
    public bool HasHei { get; private set; }
    public bool HasMdc { get; private set; }
    public bool HasMda { get; private set; }
    public bool HasTyp { get; private set; }
    public bool Fx { get; private set; }
    #endregion
    
    #region SubField Items
    public I062340Sf1SensorIdentification SensorIdentification { get; private set; }
    public I062340Sf2MeasuredPosition MeasuredPosition { get; private set; }
    public I062340Sf3Measured3dHeightInTwoComplement HeightInTwoComplement { get; private set; }
    public I062340Sf4LastMeasuredModeCCode LastMeasuredModeCCode { get; private set; }
    public I062340Sf5LastMeasuredMode3ACode LastMeasuredMode3ACode { get; private set; }
    public I062340Sf6ReportType ReportType { get; private set; }
    #endregion

    public I062340MeasuredInformation(byte[] buffer, int offset)
    {
        Name = "I062/340, Measured Information";
        IsMandatory = false;
        
        ParseExtentableData(MaxMeasuredInformationLength, buffer, offset);
        offset += Length;

        ExtractSubFieldFlag();
        
        ParseSubFields(buffer, offset);
    }

    private void ExtractSubFieldFlag()
    {
        HasSid = BitOperations.GetBit(RawData, 0);
        HasPos = BitOperations.GetBit(RawData, 1);
        HasHei = BitOperations.GetBit(RawData, 2);
        HasMdc = BitOperations.GetBit(RawData, 3);
        HasMda = BitOperations.GetBit(RawData, 4);
        HasTyp = BitOperations.GetBit(RawData, 5);
        // BitOperations.GetBit(RawData, 6);   // Spare
        Fx = BitOperations.GetBit(RawData, 7);
    }

    private void ParseSubFields(byte[] buffer, int offset)
    {
        if (HasSid)
        {
            SensorIdentification = new I062340Sf1SensorIdentification(buffer, offset);
            offset += SensorIdentification.Length;
            Length += SensorIdentification.Length;
        }

        if (HasPos)
        {
            MeasuredPosition = new I062340Sf2MeasuredPosition(buffer, offset);
            offset += MeasuredPosition.Length;
            Length += MeasuredPosition.Length;
        }

        if (HasHei)
        {
            HeightInTwoComplement = new I062340Sf3Measured3dHeightInTwoComplement(buffer, offset);
            offset += HeightInTwoComplement.Length;
            Length += HeightInTwoComplement.Length;
        }

        if (HasMdc)
        {
            LastMeasuredModeCCode = new I062340Sf4LastMeasuredModeCCode(buffer, offset);
            offset += LastMeasuredModeCCode.Length;
            Length += LastMeasuredModeCCode.Length;
        }

        if (HasMda)
        {
            LastMeasuredMode3ACode = new I062340Sf5LastMeasuredMode3ACode(buffer, offset);
            offset += LastMeasuredMode3ACode.Length;
            Length += LastMeasuredMode3ACode.Length;
        }

        if (HasTyp)
        {
            ReportType = new I062340Sf6ReportType(buffer, offset);
            offset += ReportType.Length;
            Length += ReportType.Length;
        }
    }
}