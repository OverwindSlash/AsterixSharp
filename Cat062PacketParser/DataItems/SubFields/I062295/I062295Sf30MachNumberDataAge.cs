using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf30MachNumberDataAge : FixLengthDataItem
{
    public const int MachNumberDataAgeLength = 1;

    public I062295Sf30MachNumberDataAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Mach Number Data Age";
        IsMandatory = false;
        
        LoadRawData(MachNumberDataAgeLength, buffer, offset);
        
        // TODO
    }
}