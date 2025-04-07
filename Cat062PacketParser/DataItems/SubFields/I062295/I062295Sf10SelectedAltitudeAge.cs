using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062295Sf10SelectedAltitudeAge : FixLengthDataItem
{
    public const int SelectedAltitudeAgeLength = 1;

    public I062295Sf10SelectedAltitudeAge(byte[] buffer, int offset)
    {
        Name = "I062/295, Selected Altitude Age";
        IsMandatory = false;
        
        LoadRawData(SelectedAltitudeAgeLength, buffer, offset);
        
        // TODO
    }
}