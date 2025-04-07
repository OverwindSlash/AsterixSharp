using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062380;

public class I062380Sf7FinalStateSelectedAltitude : FixLengthDataItem
{
    public const int FinalStateSelectedAltitudeLength = 2;
    public const short LSB = 25;
    
    public bool IsManageVerticalModeActive { get; private set; }
    public bool IsAltitudeHoldActive { get; private set; }
    public bool IsApproachModeActive { get; private set; }
    public int Altitude { get; private set; }

    public I062380Sf7FinalStateSelectedAltitude(byte[] buffer, int offset)
    {
        Name = "I062/380, Final State Selected Altitude";
        IsMandatory = false;
        
        LoadRawData(FinalStateSelectedAltitudeLength, buffer, offset);

        IsManageVerticalModeActive = BitOperations.GetBit(RawData, 0);
        IsAltitudeHoldActive = BitOperations.GetBit(RawData, 1);
        IsApproachModeActive = BitOperations.GetBit(RawData, 2);

        var altValue = (short)BitOperations.ConvertBitsBigEndianSigned(RawData, 3, 13);
        Altitude = altValue * LSB;
    }
}