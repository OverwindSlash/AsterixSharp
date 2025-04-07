using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf18PreEmergencyCallsign : FixLengthDataItem
{
    public const int PreEmergencyCallsignLength = 7;

    public I062390Sf18PreEmergencyCallsign(byte[] buffer, int offset)
    {
        Name = "I062/390, Pre-Emergency Callsign";
        IsMandatory = false;
        
        LoadRawData(PreEmergencyCallsignLength, buffer, offset);
        
        // TODO
    }
}