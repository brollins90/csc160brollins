using System;
using System.Numerics;
using System.Text;

namespace GameOfLife.Extensions
{
    public static class BigIntExtensionMethods
    {
        public static void SetBit(this BigInteger value, int bit, out BigInteger o)
        {
            //BigInteger mask = BigInteger.One << bit;
            o = value | (BigInteger.One << bit);
        }

        public static void UnsetBit(this BigInteger value, int bit, out BigInteger o)
        {
            //BigInteger mask = BigInteger.One << bit;
            o = value & ~(BigInteger.One << bit);
        }

        public static bool IsSet(this BigInteger value, int bit)
        {
            //BigInteger i = value & (BigInteger.One << bit);
            //Console.WriteLine(i.ToBinaryString());
            return (value & (BigInteger.One << bit)) != 0;
        }

        public static int BitValue(this BigInteger value, int bit)
        {
            return ((value & (BigInteger.One << bit)) != 0) ? 1 : 0;
        }

        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.Sign == 1)
            {
                base2.Append('0');
            }

            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                base2.Append(Convert.ToString(bytes[idx], 2).PadLeft(8, '0'));
            }

            return base2.ToString();
        }
    }
}
