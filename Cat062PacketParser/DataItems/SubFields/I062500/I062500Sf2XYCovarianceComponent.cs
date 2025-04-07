using AsterixCore;
using Utils;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf2XYCovarianceComponent : FixLengthDataItem
{
    public const int XYCovarianceComponentLength = 2;
    public const double LSB = 0.5;

    public double CovXYCovarianceComponent { get; private set; }

    public I062500Sf2XYCovarianceComponent(byte[] buffer, int offset)
    {
        Name = "I062/500, XY covariance component";
        IsMandatory = false;
        
        LoadRawData(XYCovarianceComponentLength, buffer, offset);

        var covValue = BitOperations.ConvertBitsBigEndianUnsigned(RawData, 0, 16);
        CovXYCovarianceComponent = covValue * LSB;
    }
}