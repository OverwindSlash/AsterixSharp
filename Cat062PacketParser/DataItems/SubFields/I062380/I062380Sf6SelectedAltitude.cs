using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields;

public class I062380Sf6SelectedAltitude : FixLengthDataItem
{
    public const int SelectedAltitudeLength = 2;
    public const short LSB = 25;
    
    public bool IsSourceInformationProvided { get; private set; }
    public byte Source { get; private set; }
    public int Altitude { get; private set; }
    
    public I062380Sf6SelectedAltitude(byte[] buffer, int offset)
    {
        Name = "I062/380, Selected Altitude";
        IsMandatory = false;
        
        LoadRawData(SelectedAltitudeLength, buffer, offset);

        IsSourceInformationProvided = BitOperations.GetBit(RawData, 0);
        Source = (byte)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 1, 2);
        var altValue = (short)BitOperations.ConvertBitsBigEndianSigned(RawData, 3, 13);
        Altitude = altValue * LSB;
    }
}