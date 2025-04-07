using Utils;

namespace AsterixCore;

public class ExtentableDataItem : DataItemBase
{
    public byte[] RawData { get; protected set; }
    public int Length { get; protected set; }

    protected void ParseExtentableData(int maxItemCount, byte[] buffer, int offset)
    {
        RawData = new byte[maxItemCount];
        bool fx = true;

        while (fx)
        {
            RawData[Length] = buffer[offset++];
            fx = BitOperations.GetBit(RawData[Length++], 7);
        }
    }
}