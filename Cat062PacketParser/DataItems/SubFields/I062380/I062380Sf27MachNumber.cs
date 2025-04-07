using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf27MachNumber : FixLengthDataItem
{
    public const int MachNumberLength = 2;

    public I062380Sf27MachNumber(byte[] buffer, int offset)
    {
        Name = "I062/380, Mach Number";
        IsMandatory = false;
        
        LoadRawData(MachNumberLength, buffer, offset);
        
        // TODO
    }
}