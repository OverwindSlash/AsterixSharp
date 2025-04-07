using Utils;

namespace AsterixCore;

public class RepeatableDataItem : DataItemBase
{
    public byte[] RawData { get; protected set; }
    public int Length { get; protected set; }
    
    public int RepeatCount { get; protected set; }

    public void LoadRepeatCountItem(int repeatItemSize, byte[] buffer, int offset)
    {
        for (int i = 0; i < repeatItemSize; i++)
        {
            RawData[Length++] = buffer[offset + i];
        }
        
        RepeatCount = (int)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, Length);
    }
}