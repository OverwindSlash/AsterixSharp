using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf5LastMeasuredMode3ACode : FixLengthDataItem
{
    public const int LastMeasuredMode3ACodeLength = 2;

    public I062340Sf5LastMeasuredMode3ACode(byte[] buffer, int offset)
    {
        Name = "I062/340, Last Measured Mode 3/A Code";
        IsMandatory = false;
        
        LoadRawData(LastMeasuredMode3ACodeLength, buffer, offset);
        
        // TODO
    }
}