using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf14StandStatus : FixLengthDataItem
{
    public const int StandStatusLength = 1;

    public I062390Sf14StandStatus(byte[] buffer, int offset)
    {
        Name = "I062/390, Stand Status";
        IsMandatory = false;
        
        LoadRawData(StandStatusLength, buffer, offset);
        
        // TODO
    }
}