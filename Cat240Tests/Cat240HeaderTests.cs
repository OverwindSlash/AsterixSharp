using Cat240PacketParser;

namespace Cat240Tests
{
    public class Cat240HeaderTests
    {
        private byte[] _buffer;

        private byte[] LoadShanghaiData()
        {
            return File.ReadAllBytes("data/cat240-1.bin");
        }

        [Test]
        public void TestGenerateCat062HeaderWithCambridgePixelSimulatorData()
        {
            _buffer = LoadShanghaiData();

            var cat240Header = new Cat240Header(_buffer);

            Assert.That(cat240Header.HasDataSourceIdentifier, Is.True);
            Assert.That(cat240Header.HasMessageType, Is.True);
            Assert.That(cat240Header.HasVideoRecordHeader, Is.True);
            Assert.That(cat240Header.HasVideoSummary, Is.False);
            Assert.That(cat240Header.HasVideoHeaderNano, Is.False);
            Assert.That(cat240Header.HasVideoHeaderFemto, Is.True);
            Assert.That(cat240Header.HasVideoCellsResolutionDataCompressionIndicator, Is.True);
            Assert.That(cat240Header.Fx1, Is.True);

            Assert.That(cat240Header.HasVideoOctetsVideoCellsCounters, Is.True);
            Assert.That(cat240Header.HasVideoBlockLowDataVolume, Is.False);
            Assert.That(cat240Header.HasVideoBlockMediumDataVolume, Is.True);
            Assert.That(cat240Header.HasVideoBlockHighDataVolume, Is.False);
            Assert.That(cat240Header.HasTimeOfDay, Is.True);
            Assert.That(cat240Header.HasReservedExpansionField, Is.False);
            Assert.That(cat240Header.HasSpecialPurposeField, Is.False);
            Assert.That(cat240Header.Fx2, Is.False);
        }
    }
}
