namespace AsterixCore;

public class FixLengthDataItem : DataItemBase
{
    public byte[] RawData { get; protected set; }
    public int Length { get; protected set; }

    protected void LoadRawData(int dateItemLength, byte[] buffer, int offset)
    {
        Length = dateItemLength;
        RawData = new byte[Length];
        
        for (int i = 0; i < Length; i++)
        {
            RawData[i] = buffer[offset + i];
        }
    }
}