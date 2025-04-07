using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062500;

public class I062500Sf2XYCovarianceComponent : FixLengthDataItem
{
    public const int XYCovarianceComponentLength = 2;

    public I062500Sf2XYCovarianceComponent(byte[] buffer, int offset)
    {
        Name = "I062/500, XY covariance component";
        IsMandatory = false;
        
        LoadRawData(XYCovarianceComponentLength, buffer, offset);
        
        // TODO
    }
}