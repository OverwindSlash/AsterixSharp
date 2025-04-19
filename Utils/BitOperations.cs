using System.Text;

namespace Utils;

using System;

public static class BitOperations
{
    private const int BitsPerByte = 8;
    
    /// <summary>
    /// 获取 data 中全局 bitIndex 处的位（MSB 编号：bit0 为最高位）。
    /// </summary>
    /// <param name="data">要操作的 byte 数据</param>
    /// <param name="bitIndex">位索引（0 到 7）</param>
    /// <returns>指定位置的位，1 返回 true，0 返回 false</returns>
    public static bool GetBit(byte data, int bitIndex)
    {
        if (bitIndex < 0 || bitIndex >= 8)
            throw new ArgumentOutOfRangeException(nameof(bitIndex));

        return ((data >> (7 - bitIndex)) & 1) == 1;
    }
    
    /// <summary>
    /// 获取 data 数组中全局 bitIndex 处的位（MSB 编号：每个字节 bit0 为最高位）。
    /// </summary>
    public static bool GetBit(byte[] data, int bitIndex)
    {
        if (data == null)
            throw new ArgumentNullException(nameof(data));
        if (bitIndex < 0 || bitIndex >= data.Length * 8)
            throw new ArgumentOutOfRangeException(nameof(bitIndex));

        int byteIndex = bitIndex / 8;
        int bitInByte = bitIndex % 8; // bit0 为最高有效位
        return ((data[byteIndex] >> (7 - bitInByte)) & 1) == 1;
    }

    /// <summary>
    /// BigEndian 模式下，无符号转换：从 data 数组中，从 startBit 开始提取 bitLength 个位，返回 long 值。
    /// 按照 MSB 规则：第一个提取的位作为最高有效位。
    /// </summary>
    public static long ConvertBitsBigEndianUnsigned(byte[] data, int startBit, int bitLength)
    {
        ArgumentNullException.ThrowIfNull(data);
        if (bitLength <= 0)
            throw new ArgumentException("bitLength must be positive", nameof(bitLength));
        if (startBit < 0 || startBit + bitLength > data.Length * 8)
            throw new ArgumentOutOfRangeException(nameof(startBit));

        long result = 0;
        for (int i = 0; i < bitLength; i++)
        {
            if (GetBit(data, startBit + i))
                result |= 1L << (bitLength - 1 - i);
        }
        return result;
    }

    /// <summary>
    /// BigEndian 模式下，有符号转换：从 data 数组中，从 startBit 开始提取 bitLength 个位，
    /// 并以二进制补码规则返回 long 值。
    /// </summary>
    public static long ConvertBitsBigEndianSigned(byte[] data, int startBit, int bitLength)
    {
        long unsignedValue = ConvertBitsBigEndianUnsigned(data, startBit, bitLength);
        
        // 如果最高位为 1，则进行符号扩展：减去 1<<bitLength
        if ((unsignedValue & (1L << (bitLength - 1))) != 0)
        {
            unsignedValue -= 1L << bitLength;
        }
        return unsignedValue;
    }

    /// <summary>
    /// LittleEndian 模式下，无符号转换：从 data 数组中，从 startBit 开始提取 bitLength 个位，返回 long 值。
    /// 当 bitLength 为 8 的倍数时，将按字节反转顺序；否则，按位直接计算，第一个提取的位作为最低位。
    /// </summary>
    public static long ConvertBitsLittleEndianUnsigned(byte[] data, int startBit, int bitLength)
    {
        ArgumentNullException.ThrowIfNull(data);
        if (bitLength <= 0)
            throw new ArgumentException("bitLength must be positive", nameof(bitLength));
        if (startBit < 0 || startBit + bitLength > data.Length * 8)
            throw new ArgumentOutOfRangeException(nameof(startBit));

        // 如果 bitLength 是 8 的倍数，则先按大端方式提取，再交换字节顺序
        if (bitLength % 8 == 0)
        {
            long bigEndianValue = ConvertBitsBigEndianUnsigned(data, startBit, bitLength);
            int byteCount = bitLength / 8;
            long result = 0;
            for (int i = 0; i < byteCount; i++)
            {
                long byteVal = (bigEndianValue >> ((byteCount - 1 - i) * 8)) & 0xFF;
                result |= byteVal << (i * 8);
            }
            return result;
        }
        else
        {
            // 非 8 的倍数：直接按位计算，将第 0 个提取的位作为最低位
            long result = 0;
            for (int i = 0; i < bitLength; i++)
            {
                if (GetBit(data, startBit + i))
                    result |= 1L << i;
            }
            return result;
        }
    }

    /// <summary>
    /// LittleEndian 模式下，有符号转换：从 data 数组中，从 startBit 开始提取 bitLength 个位，
    /// 并以二进制补码规则返回 long 值。
    /// </summary>
    public static long ConvertBitsLittleEndianSigned(byte[] data, int startBit, int bitLength)
    {
        long unsignedValue = ConvertBitsLittleEndianUnsigned(data, startBit, bitLength);
        if ((unsignedValue & (1L << (bitLength - 1))) != 0)
        {
            unsignedValue -= 1L << bitLength;
        }
        return unsignedValue;
    }

    public static ushort Get2BytesUnSignedBigEndian(byte[] buffer, int offset)
    {
        var result = ConvertBitsBigEndianUnsigned(buffer, offset * BitsPerByte, 2 * BitsPerByte);
        return (ushort)result;
    }
    
    public static ushort Get2BytesSignedBigEndian(byte[] buffer, int offset)
    {
        var result = ConvertBitsBigEndianSigned(buffer, offset * BitsPerByte, 2 * BitsPerByte);
        return (ushort)result;
    }
    
    public static uint Get3BytesUnSignedBigEndian(byte[] buffer, int offset)
    {
        var result = ConvertBitsBigEndianUnsigned(buffer, offset * BitsPerByte, 3 * BitsPerByte);
        return (uint)result;
    }

    public static uint Get4BytesUnSignedBigEndian(byte[] buffer, int offset)
    {
        var result = ConvertBitsBigEndianUnsigned(buffer, offset * BitsPerByte, 4 * BitsPerByte);
        return (uint)result;
    }

    public static string ConvertBytesTo6BitsAscii(byte[] targetBytes, int startIndex, int numChars)
    {
        if (targetBytes == null)
            throw new ArgumentNullException(nameof(targetBytes));
        if (numChars < 0)
            throw new ArgumentException("指定的字符数不能为负。", nameof(numChars));
        if (startIndex < 0 || startIndex >= targetBytes.Length)
            throw new ArgumentOutOfRangeException(nameof(startIndex), "起始索引超出字节数组范围。");

        // 从 startIndex 开始的总位数
        int totalBits = (targetBytes.Length - startIndex) * 8;
        if (totalBits < numChars * 6)
            throw new ArgumentException("从指定起始索引开始的字节数组不足以解析指定数量的字符。");

        StringBuilder sb = new StringBuilder();
        // 从 startIndex 处开始读取，计算起始的位索引
        int bitIndex = startIndex * 8;

        // 依次读取每个 6 位分组
        for (int group = 0; group < numChars; group++)
        {
            int sixBits = 0;
            // 每个分组读取 6 位
            for (int i = 0; i < 6; i++)
            {
                sixBits <<= 1;
                int byteIndex = bitIndex / 8;
                int bitPosition = 7 - (bitIndex % 8); // 高位在前
                int bit = (targetBytes[byteIndex] >> bitPosition) & 1;
                sixBits |= bit;
                bitIndex++;
            }

            // 如果读取到的 6 位全为 0，则认为后续数据为补齐数据，提前结束解析
            if (sixBits == 0)
                break;

            char c;
            if (sixBits >= 1 && sixBits <= 26)
            {
                // 1~26 映射为大写字母（1+64='A'）
                c = (char)(sixBits + 64);
            }
            else
            {
                // 其它数值直接转换为对应的 ASCII 字符
                c = (char)sixBits;
            }
            sb.Append(c);
        }

        return sb.ToString();
    }
}