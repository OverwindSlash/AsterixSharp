using AsterixCore;

namespace Cat062PacketParser.DataItems;

public class I062200ModeOfMovement : FixLengthDataItem
{
    public const int ModeOfMovementLength = 1;

    public I062200ModeOfMovement(byte[] buffer, int offset)
    {
        Name = "I062/200, Mode of Movement";
        IsMandatory = false;
        
        LoadRawData(ModeOfMovementLength, buffer, offset);
        
        // TODO
    }
}