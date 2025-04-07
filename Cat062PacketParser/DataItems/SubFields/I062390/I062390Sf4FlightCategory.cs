using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf4FlightCategory : FixLengthDataItem
{
    public const int FlightCategoryLength = 1;

    public I062390Sf4FlightCategory(byte[] buffer, int offset)
    {
        Name = "I062/390, Flight Category";
        IsMandatory = false;
        
        LoadRawData(FlightCategoryLength, buffer, offset);
        
        // TODO
    }
}