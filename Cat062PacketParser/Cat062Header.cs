using Utils;

namespace Cat062PacketParser;

public class Cat062Header
{
    private const int BitsPerByte = 8;
    private const int FieldSpecTotalBits = 48;
    
    public byte Category { get; private set; }
    public ushort DataBlockLength { get; private set; }
    public List<bool> FieldSpecFlags { get; private set; }
    public int Offset { get; private set; }

    public Cat062Header(byte[] buffer)
    {
        Offset = 0;

        // CAT 标志位，1 byte
        Category = buffer[Offset++];
        if (Category != 0x3E)
        {
            throw new InvalidOperationException("Invalid package header: Category mismatch.");
        }

        // Data block 长度，2 bytes
        DataBlockLength = BitOperations.Get2BytesUnSignedBigEndian(buffer, Offset);
        Offset += 2;

        // 解析 FieldSpec
        FieldSpecFlags = [];
        bool fx = true;

        while (fx)
        {
            int bitOffset = Offset * BitsPerByte;
            for (int i = 0; i < 8; i++)
            {
                FieldSpecFlags.Add(BitOperations.GetBit(buffer, bitOffset + i));
            }

            fx = FieldSpecFlags.Last();
            Offset++;
        }

        // 补全后续的空缺项
        for (int i = FieldSpecFlags.Count; i < FieldSpecTotalBits; i++)
        {
            FieldSpecFlags.Add(false);
        }
    }

    public bool HasDataSourceIdentifier => FieldSpecFlags[0];
    // FieldSpecFlags[1] is Spare
    public bool HasServiceIdentification => FieldSpecFlags[2];
    public bool HasTimeOfTrackInformation => FieldSpecFlags[3];
    public bool HasCalculatedTrackPositionWgs84 => FieldSpecFlags[4];
    public bool HasCalculatedTrackPositionCartesian => FieldSpecFlags[5];
    public bool HasCalculatedTrackVelocityCartesian => FieldSpecFlags[6];
    public bool Fx1 => FieldSpecFlags[7];

    public bool HasCalculatedAccelerationCartesian => Fx1 && FieldSpecFlags[8];
    public bool HasTrackMode3ACode => Fx1 && FieldSpecFlags[9];
    public bool HasTargetIdentification => Fx1 && FieldSpecFlags[10];
    public bool HasAircraftDerivedData => Fx1 && FieldSpecFlags[11];
    public bool HasTrackNumber => Fx1 && FieldSpecFlags[12];
    public bool HasTrackStatus => Fx1 && FieldSpecFlags[13];
    public bool HasSystemTrackUpdateAges => Fx1 && FieldSpecFlags[14];
    public bool Fx2 => Fx1 && FieldSpecFlags[15];

    public bool HasModeOfMovement => Fx2 && FieldSpecFlags[16];
    public bool HasTrackDataAges => Fx2 && FieldSpecFlags[17];
    public bool HasMeasuredFlightLevel => Fx2 && FieldSpecFlags[18];
    public bool HasCalculatedTrackGeometricAltitude => Fx2 && FieldSpecFlags[19];
    public bool HasCalculatedTrackBarometricAltitude => Fx2 && FieldSpecFlags[20];
    public bool HasCalculatedRateOfClimbDescent => Fx2 && FieldSpecFlags[21];
    public bool HasFlightPlanRelatedData => Fx2 && FieldSpecFlags[22];
    public bool Fx3 => Fx2 && FieldSpecFlags[23];

    public bool HasTargetSizeAndOrientation => Fx3 && FieldSpecFlags[24];
    public bool HasVehicleFleetIdentification => Fx3 && FieldSpecFlags[25];
    public bool HasMode5DataReportsAndExtendedMode1Code => Fx3 && FieldSpecFlags[26];
    public bool HasTrackMode2Code => Fx3 && FieldSpecFlags[27];
    public bool HasComposedTrackNumber => Fx3 && FieldSpecFlags[28];
    public bool HasEstimatedAccuracies => Fx3 && FieldSpecFlags[29];
    public bool HasMeasuredInformation => Fx3 && FieldSpecFlags[30];
    public bool Fx4 => FieldSpecFlags[31];

    // FieldSpecFlags[32] is Spare
    // FieldSpecFlags[33] is Spare
    // FieldSpecFlags[34] is Spare
    // FieldSpecFlags[35] is Spare
    // FieldSpecFlags[36] is Spare
    public bool HasReservedExpansionField => Fx4 && FieldSpecFlags[37];
    public bool HasReservedForSpecialPurposeIndicator => Fx4 && FieldSpecFlags[38];
    public bool Fx5 => FieldSpecFlags[39];
}