using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062340;

public class I062340Sf3Measured3dHeightInTwoComplement : FixLengthDataItem
{
    public const int Measured3dHeightInTwoComplementLength = 2;
    public const int HEIGHT_LSB = 25;

    public int Measured3dHeight { get; private set; }

    public I062340Sf3Measured3dHeightInTwoComplement(byte[] buffer, int offset)
    {
        Name = "I062/340, Measured 3-D Height in Two’s Complement";
        IsMandatory = false;
        
        LoadRawData(Measured3dHeightInTwoComplementLength, buffer, offset);

        var heightValue = (short)BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        Measured3dHeight = heightValue * HEIGHT_LSB;
    }
}