namespace Cat062PacketParser
{
    public class Cat062DataBlock
    {
        public Cat062Header Header { get; set; }
        public Cat062DataItems Items { get; set; }

        public Cat062DataBlock(byte[] buffer, int size)
        {
            Header = new Cat062Header(buffer);
            Items = new Cat062DataItems(Header, buffer, size);
        }
    }
}
