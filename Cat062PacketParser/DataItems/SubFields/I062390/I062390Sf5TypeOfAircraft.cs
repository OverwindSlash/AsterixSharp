using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf5TypeOfAircraft : FixLengthDataItem
{
    public const int TypeOfAircraftLength = 4;

    public I062390Sf5TypeOfAircraft(byte[] buffer, int offset)
    {
        Name = "I062/390, Type Of Aircraft";
        IsMandatory = false;
        
        LoadRawData(TypeOfAircraftLength, buffer, offset);
        
        // TODO
    }
}