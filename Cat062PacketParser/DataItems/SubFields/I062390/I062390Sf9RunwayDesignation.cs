using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf9RunwayDesignation : FixLengthDataItem
{
    public const int RunwayDesignationLength = 3;

    public I062390Sf9RunwayDesignation(byte[] buffer, int offset)
    {
        Name = "I062/390, Runway Designation";
        IsMandatory = false;
        
        LoadRawData(RunwayDesignationLength, buffer, offset);
        
        // TODO
    }
}