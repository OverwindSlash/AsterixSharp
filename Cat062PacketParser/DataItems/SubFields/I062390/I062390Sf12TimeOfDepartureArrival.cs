using AsterixCore;

namespace Cat062PacketParser.DataItems.SubFields.I062390;

public class I062390Sf12TimeOfDepartureArrival : RepeatableDataItem
{
    public const int TimeOfDepartureArrivalRepeatCountLength = 1;
    
    public List<I062390Sf12TimeOfDepartureArrivalBody> TimeOfDepartureArrivalItems = new();

    public I062390Sf12TimeOfDepartureArrival(byte[] buffer, int offset)
    {
        Name = "I062/380, Time of Departure Arrival";
        IsMandatory = false;
        
        LoadRepeatCountItem(TimeOfDepartureArrivalRepeatCountLength, buffer, offset);
        offset += TimeOfDepartureArrivalRepeatCountLength;

        for (int i = 0; i < RepeatCount; i++)
        {
            var body = new I062390Sf12TimeOfDepartureArrivalBody(buffer, offset);
            TimeOfDepartureArrivalItems.Add(body);
            offset += body.Length;
        }
    }
}