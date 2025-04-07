using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf6WakeTurbulenceCategory : FixLengthDataItem
{
    public const int WakeTurbulenceCategoryLength = 1;

    public I062390Sf6WakeTurbulenceCategory(byte[] buffer, int offset)
    {
        Name = "I062/390, Wake Turbulence Category";
        IsMandatory = false;
        
        LoadRawData(WakeTurbulenceCategoryLength, buffer, offset);
        
        // TODO
    }
}