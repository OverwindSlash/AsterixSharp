using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf6TimeOffsetForPosAndGa : FixLengthDataItem
{
    public const int TimeOffsetForPosAndGaLength = 1;

    public I062110Sf6TimeOffsetForPosAndGa(byte[] buffer, int offset)
    {
        Name = "I062/110, Time Offset for POS and GA";
        IsMandatory = false;
        
        LoadRawData(TimeOffsetForPosAndGaLength, buffer, offset);
        
        // TODO
    }
}