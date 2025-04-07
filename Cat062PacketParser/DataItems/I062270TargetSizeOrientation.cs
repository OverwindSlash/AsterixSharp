using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062270TargetSizeOrientation : ExtentableDataItem
{
    public const int MaxTargetSizeOrientationLength = 3;
    
    public byte Length { get; private set; }
    public bool Fx1 { get; private set; }
    
    public byte Orientation { get; private set; }
    public bool Fx2 { get; private set; }
    
    public byte Width { get; private set; }
    public bool Fx3 { get; private set; }

    public I062270TargetSizeOrientation(byte[] buffer, int offset)
    {
        Name = "I062/270, Target Size & Orientation";
        IsMandatory = false;
        
        ParseExtentableData(MaxTargetSizeOrientationLength, buffer, offset);
        
        // TODO
    }
}