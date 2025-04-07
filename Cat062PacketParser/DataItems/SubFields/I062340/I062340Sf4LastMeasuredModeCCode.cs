using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf4LastMeasuredModeCCode : FixLengthDataItem
{
    public const int LastMeasuredModeCCodeLength = 2;

    public I062340Sf4LastMeasuredModeCCode(byte[] buffer, int offset)
    {
        Name = "I062/340, Last Measured Mode C Code";
        IsMandatory = false;
        
        LoadRawData(LastMeasuredModeCCodeLength, buffer, offset);
        
        // TODO
    }
}