namespace AsterixCore;

public class ExtentableDataItemWithSubFields : ExtentableDataItem
{
    public List<FixLengthDataItem> SubFields { get; private set; }
}