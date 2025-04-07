using Utils;

namespace UtilsTests;

[TestFixture]
public class BitOperationsTests
{
    // 使用 0xAA (10101010) 测试每个位的值
    [Test]
    public void Test_GetBit_Normal_AA()
    {
        byte data = 0xAA; // 二进制：10101010，按 MSB 编号：
        // bit0 = 1, bit1 = 0, bit2 = 1, bit3 = 0, bit4 = 1, bit5 = 0, bit6 = 1, bit7 = 0
        Assert.IsTrue(BitOperations.GetBit(data, 0), "0xAA: bit0 应为 true");
        Assert.IsFalse(BitOperations.GetBit(data, 1), "0xAA: bit1 应为 false");
        Assert.IsTrue(BitOperations.GetBit(data, 2), "0xAA: bit2 应为 true");
        Assert.IsFalse(BitOperations.GetBit(data, 3), "0xAA: bit3 应为 false");
        Assert.IsTrue(BitOperations.GetBit(data, 4), "0xAA: bit4 应为 true");
        Assert.IsFalse(BitOperations.GetBit(data, 5), "0xAA: bit5 应为 false");
        Assert.IsTrue(BitOperations.GetBit(data, 6), "0xAA: bit6 应为 true");
        Assert.IsFalse(BitOperations.GetBit(data, 7), "0xAA: bit7 应为 false");
    }

    // 使用 0x80 (10000000) 测试：仅最高位为 1，其余均为 0
    [Test]
    public void Test_GetBit_Normal_80()
    {
        byte data = 0x80; // 二进制：10000000
        Assert.IsTrue(BitOperations.GetBit(data, 0), "0x80: bit0 应为 true");
        for (int i = 1; i < 8; i++)
        {
            Assert.IsFalse(BitOperations.GetBit(data, i), $"0x80: bit{i} 应为 false");
        }
    }

    // 使用 0x01 (00000001) 测试：仅最低位为 1，其余均为 0
    [Test]
    public void Test_GetBit_Normal_01()
    {
        byte data = 0x01; // 二进制：00000001
        for (int i = 0; i < 7; i++)
        {
            Assert.IsFalse(BitOperations.GetBit(data, i), $"0x01: bit{i} 应为 false");
        }

        Assert.IsTrue(BitOperations.GetBit(data, 7), "0x01: bit7 应为 true");
    }

    // 测试非法索引：负数索引应抛出异常
    [Test]
    public void Test_GetBit_InvalidIndex_Negative()
    {
        byte data = 0xFF;
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.GetBit(data, -1));
    }

    // 测试非法索引：索引超出范围（>=8）应抛出异常
    [Test]
    public void Test_GetBit_InvalidIndex_TooHigh()
    {
        byte data = 0xFF;
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.GetBit(data, 8));
    }

    // 场景 1.1：正常位验证
    [Test]
    public void Test_GetBit_Normal()
    {
        // 使用 0xAA (10101010) 测试
        byte[] data = [0xAA];

        // 按 MSB 编号，bit0 应为 1，bit1 应为 0
        Assert.That(BitOperations.GetBit(data, 0), Is.True, "Bit 0 应为 1。");
        Assert.That(BitOperations.GetBit(data, 1), Is.False, "Bit 1 应为 0。");
    }

    // 场景 1.2：边界位验证
    [Test]
    public void Test_GetBit_Boundaries()
    {
        // 使用 0x80 (10000000) 和 0x01 (00000001)
        byte[] data = [0x80, 0x01];

        Assert.Multiple(() =>
        {
            // 第一个字节：bit0 (MSB) 应为 1，bit7 (LSB) 应为 0
            Assert.That(BitOperations.GetBit(data, 0), Is.True, "第一个字节的 bit0 应为 1。");
            Assert.That(BitOperations.GetBit(data, 7), Is.False, "第一个字节的 bit7 应为 0。");
        });

        // 第二个字节：全局 bit 索引 15 对应第二字节的 bit7，应为 1
        Assert.That(BitOperations.GetBit(data, 15), Is.True, "第二个字节的 bit7 应为 1。");
    }

    // 场景 1.3：非法位索引
    [Test]
    public void Test_GetBit_InvalidIndex()
    {
        byte[] data = [0xAA];

        // 测试负数索引和超出有效范围的索引
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.GetBit(data, -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.GetBit(data, 8));
    }

    // 场景 2.1：单比特转换（BigEndian 模式）
    [Test]
    public void Test_ConvertBits_SingleBit_BigEndian()
    {
        byte[] data = [0x80]; // 10000000

        // 仅提取从 bit0 开始 1 位
        long resultUnsigned = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 1);
        long resultSigned = BitOperations.ConvertBitsBigEndianSigned(data, 0, 1);
        Assert.That(resultUnsigned, Is.EqualTo(1), "BigEndian 无符号单比特转换应为 1。");
        Assert.That(resultSigned, Is.EqualTo(-1), "BigEndian 有符号单比特转换应为 -1。");
    }

    // 场景 2.2：单字节内连续位转换（BigEndian 模式）
    [Test]
    public void Test_ConvertBits_SingleByte_BigEndian()
    {
        byte[] data = [0xD2]; // 二进制：11010010

        // 提取从 bit2 开始 4 位，即取得 0,1,0,0 → "0100" => 4
        long resultUnsigned = BitOperations.ConvertBitsBigEndianUnsigned(data, 2, 4);
        long resultSigned = BitOperations.ConvertBitsBigEndianSigned(data, 2, 4);
        Assert.That(resultUnsigned, Is.EqualTo(4), "BigEndian 无符号转换 (bit2 开始 4 位) 应为 4。");
        Assert.That(resultSigned, Is.EqualTo(4), "BigEndian 有符号转换 (bit2 开始 4 位) 应为 4。");
    }

    // 场景 2.3：跨字节转换（Endian 效果验证）
    [Test]
    public void Test_ConvertBits_CrossByte_Endianness()
    {
        byte[] data = [0xAB, 0xCD];

        // 全 16 位提取（从 bit0 开始 16 位）
        long unsignedBigEndian = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 16);
        long unsignedLittleEndian = BitOperations.ConvertBitsLittleEndianUnsigned(data, 0, 16);
        Assert.That(unsignedBigEndian, Is.EqualTo(0xABCD), "BigEndian 模式下应得到 0xABCD。");
        Assert.That(unsignedLittleEndian, Is.EqualTo(0xCDAB), "LittleEndian 模式下应得到 0xCDAB。");

        // 有符号转换：16 位数若最高位为 1，则按补码规则转换
        long signedBigEndian = BitOperations.ConvertBitsBigEndianSigned(data, 0, 16);
        long signedLittleEndian = BitOperations.ConvertBitsLittleEndianSigned(data, 0, 16);
        // 0xABCD (43981) 作为有符号 16 位数 => 43981 - 65536 = -21555
        // 0xCDAB (52651) 作为有符号 16 位数 => 52651 - 65536 = -12885
        Assert.That(signedBigEndian, Is.EqualTo(-21555), "BigEndian 有符号转换应得到 -21555。");
        Assert.That(signedLittleEndian, Is.EqualTo(-12885), "LittleEndian 有符号转换应得到 -12885。");
    }

    // 场景 2.4：整个数组转换（边界提取）
    [Test]
    public void Test_ConvertBits_EntireArray_BigEndianAndLittleEndian()
    {
        byte[] data = [0xFF, 0x00];

        // 提取整个 16 位
        long unsignedBigEndian = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 16);
        long signedBigEndian = BitOperations.ConvertBitsBigEndianSigned(data, 0, 16);
        long unsignedLittleEndian = BitOperations.ConvertBitsLittleEndianUnsigned(data, 0, 16);
        long signedLittleEndian = BitOperations.ConvertBitsLittleEndianSigned(data, 0, 16);
        // BigEndian: 0xFF00 => 65280，无符号；有符号转换应为 65280 - 65536 = -256
        Assert.That(unsignedBigEndian, Is.EqualTo(0xFF00), "BigEndian 无符号转换应为 0xFF00。");
        Assert.That(signedBigEndian, Is.EqualTo(-256), "BigEndian 有符号转换应为 -256。");
        // LittleEndian: 0x00FF => 255
        Assert.That(unsignedLittleEndian, Is.EqualTo(0x00FF), "LittleEndian 无符号转换应为 0x00FF。");
        Assert.That(signedLittleEndian, Is.EqualTo(255), "LittleEndian 有符号转换应为 255。");
    }

    // 场景 2.5：非法位范围参数
    [Test]
    public void Test_ConvertBits_InvalidParameters()
    {
        byte[] data = [0x00];

        // 对于非法的 bitLength（例如负数）
        Assert.Throws<ArgumentException>(() => BitOperations.ConvertBitsBigEndianUnsigned(data, 5, -3));

        // 对于超出实际位数的提取，data 长度 1 => 可用位数 8，若提取 9 位则应抛出异常
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 9));
    }

    // 场景 2.6：Endian 设置对比验证（32 位数据）
    [Test]
    public void Test_ConvertBits_EndianComparison()
    {
        byte[] data = new byte[] { 0x12, 0x34, 0x56, 0x78 };

        // 提取 32 位
        long resultBigEndian = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 32);
        long resultLittleEndian = BitOperations.ConvertBitsLittleEndianUnsigned(data, 0, 32);
        Assert.That(resultBigEndian, Is.EqualTo(0x12345678), "BigEndian 模式下应得到 0x12345678。");
        Assert.That(resultLittleEndian, Is.EqualTo(0x78563412), "LittleEndian 模式下应得到 0x78563412。");
    }

    // 场景 2.7：有符号转换边界测试（符号位为 1）
    [Test]
    public void Test_ConvertBits_SignedBoundary_BigEndian()
    {
        byte[] data = new byte[] { 0xF0 }; // 二进制：11110000

        // 提取从 bit0 开始 3 位，得到 "111" 
        // 无符号结果为 7，但 3 位补码中 "111" 表示 -1
        long unsignedResult = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 3);
        long signedResult = BitOperations.ConvertBitsBigEndianSigned(data, 0, 3);
        Assert.That(unsignedResult, Is.EqualTo(7), "BigEndian 无符号转换 3 位应为 7。");
        Assert.That(signedResult, Is.EqualTo(-1), "BigEndian 有符号转换 3 位应为 -1。");
    }

    // 场景 2.8：空或 Null 数组处理
    [Test]
    public void Test_NullOrEmptyArray()
    {
        byte[] nullData = null;
        Assert.Throws<ArgumentNullException>(() => BitOperations.GetBit(nullData, 0));
        Assert.Throws<ArgumentNullException>(() => BitOperations.ConvertBitsBigEndianUnsigned(nullData, 0, 1));

        byte[] emptyData = [];
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.GetBit(emptyData, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => BitOperations.ConvertBitsBigEndianUnsigned(emptyData, 0, 1));
    }

    // 场景 3.1：高频调用性能测试
    [Test]
    public void Test_Performance_HighFrequency()
    {
        // 构造一个 1,000,000 字节的大数组，并填充固定数据
        byte[] data = new byte[1000000];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = 0xAA;
        }

        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        for (int i = 0; i < 5000; i++)
        {
            // 每次调用提取前 64 位，使用 BigEndian 无符号版本和 GetBit 方法
            long convResult = BitOperations.ConvertBitsBigEndianUnsigned(data, 0, 64);
            bool bit = BitOperations.GetBit(data, 0);
        }

        stopwatch.Stop();

        // 确保 5000 次调用的总执行时间低于 100 毫秒
        Assert.Less(stopwatch.ElapsedMilliseconds, 100, "高频调用性能不达标。");
    }
}