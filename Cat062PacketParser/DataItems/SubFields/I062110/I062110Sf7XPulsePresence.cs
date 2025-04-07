using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062110;

public class I062110Sf7XPulsePresence : FixLengthDataItem
{
    public const int XPulsePresenceLength = 1;

    public I062110Sf7XPulsePresence(byte[] buffer, int offset)
    {
        Name = "I062/110, X Pulse Presence";
        IsMandatory = false;
        
        LoadRawData(XPulsePresenceLength, buffer, offset);
        
        // TODO
    }
}