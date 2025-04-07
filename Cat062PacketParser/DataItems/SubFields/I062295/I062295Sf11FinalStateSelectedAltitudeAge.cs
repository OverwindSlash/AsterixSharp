using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062295;

public class I062295Sf11FinalStateSelectedAltitudeAge : FixLengthDataItem
{
    public const int FinalStateSelectedAltitudeAgeLength = 1;

    public I062295Sf11FinalStateSelectedAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Final State Selected Altitude Age";
        IsMandatory = false;
        
        LoadRawData(FinalStateSelectedAltitudeAgeLength, buffer, offset);
        
        // TODO
    }
}