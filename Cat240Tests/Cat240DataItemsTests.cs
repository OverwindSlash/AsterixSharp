using Cat240PacketParser;

namespace Cat240Tests
{
    public class Cat240DataItemsTests
    {
        private byte[] _buffer;

        private byte[] LoadShanghaiData()
        {
            return File.ReadAllBytes("data/cat240-1.bin");
        }

        [Test]
        public void TestGenerateCat240DataItemsWithShanghaiData()
        {
            _buffer = LoadShanghaiData();

            var cat240Header = new Cat240Header(_buffer);
            var cat240DataItems = new Cat240DataItems(cat240Header, _buffer, cat240Header.DataBlockLength);

            Assert.That(cat240DataItems.SystemAreaCode, Is.EqualTo(0));
            Assert.That(cat240DataItems.SystemIdentificationCode, Is.EqualTo(0));

            Assert.That(cat240DataItems.MessageType, Is.EqualTo(2));

            Assert.That(cat240DataItems.MessageIndex, Is.EqualTo(839907370));
            
            Assert.That(cat240DataItems.StartAzimuthInDegree, Is.EqualTo(335.000610351562).Within(0.00000000001));
            Assert.That(cat240DataItems.EndAzimuthInDegree, Is.EqualTo(335.000610351562).Within(0.00000000001));
            Assert.That(cat240DataItems.StartRange, Is.EqualTo(0));
            Assert.That(cat240DataItems.CellDuration, Is.EqualTo(33333333));

            Assert.That(cat240DataItems.IsDataCompressed, Is.False);
            Assert.That(cat240DataItems.VideoResolution, Is.EqualTo(8));

            Assert.That(cat240DataItems.ValidBytesInDataBlock, Is.EqualTo(6000));
            Assert.That(cat240DataItems.ValidCellsInDataBlock, Is.EqualTo(6000));

            Assert.That(cat240DataItems.VideoBlockCount, Is.EqualTo(94));
            Assert.That(cat240DataItems.VideoBlockLength, Is.EqualTo(64));

            Assert.That(cat240DataItems.TimeOfDayInSec, Is.EqualTo(49252.921875));

            Assert.That(cat240DataItems.GetCellData(0), Is.EqualTo(125));
            Assert.That(cat240DataItems.GetCellData(1), Is.EqualTo(118));
            Assert.That(cat240DataItems.GetCellData(2), Is.EqualTo(123));

            Assert.That(cat240DataItems.GetCellData(64), Is.EqualTo(100));
            Assert.That(cat240DataItems.GetCellData(65), Is.EqualTo(74));
            Assert.That(cat240DataItems.GetCellData(66), Is.EqualTo(51));

            Assert.That(cat240DataItems.GetCellData(5824), Is.EqualTo(0));
            Assert.That(cat240DataItems.GetCellData(5833), Is.EqualTo(14));
            Assert.That(cat240DataItems.GetCellData(5839), Is.EqualTo(15));
            Assert.That(cat240DataItems.GetCellData(5844), Is.EqualTo(16));
        }
    }
}
