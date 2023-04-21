using System.Text;

namespace KtsRdbTool.RDBManager
{
    public class RDBCommon
    {
        public static string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string BytesToStringASCII(byte[] b)
        {
            bool flag;
            bool flag1;
            bool flag2;
            int num = 0;
            int num1 = 0;
            while (true)
            {
                if (num1 >= (int)b.Length)
                {
                    flag1 = false;
                }
                else
                {
                    flag1 = b[num1] > 0;
                }
                flag = flag1;
                if (!flag)
                {
                    break;
                }
                num++;
                num1++;
            }
            byte[] numArray = new byte[num];
            num1 = 0;
            while (true)
            {
                if (num1 >= num)
                {
                    flag2 = false;
                }
                else
                {
                    flag2 = b[num1] > 0;
                }
                flag = flag2;
                if (!flag)
                {
                    break;
                }
                numArray[num1] = b[num1];
                num1++;
            }
            string str = Encoding.Default.GetString(numArray);
            return str;
        }


        public static string BytesToString(byte[] b, string lang)
        {
            int num = 0;
            string str = "";
            for (int i = 0; i < (int)b.Length && b[i] > 0; i++)
            {
                num++;
            }
            byte[] numArray = new byte[num];
            for (int i = 0; i < num && b[i] > 0; i++)
            {
                numArray[i] = b[i];
            }
            if (lang == "Chinese")
                str = Encoding.GetEncoding("gb2312").GetString(numArray);
            else if (lang == "Arabic")
                str = Encoding.GetEncoding("Windows-1256").GetString(numArray);
            else if (lang == "Korean")
                str = Encoding.GetEncoding("ks_c_5601-1987").GetString(numArray);
            else if (lang == "French" || lang == "German" || lang == "Italian" || lang == "Spanish" || lang == "Portuguese")
                str = Encoding.GetEncoding("Windows-1252").GetString(numArray);
            else if (lang == "English")
                str = Encoding.GetEncoding("ASCII").GetString(numArray);
            else if (lang == "Polish")
                str = Encoding.GetEncoding("Windows-1250").GetString(numArray);
            else if (lang == "Russian")
                str = Encoding.GetEncoding("Windows-1251").GetString(numArray);
            else if (lang == "Japanese")
                str = Encoding.GetEncoding("Shift-JIS").GetString(numArray);
            else if (lang == "Turkish")
                str = Encoding.GetEncoding("Windows-1254").GetString(numArray);

            return str;
        }

        public static string BytesToString(byte[] b)
        {
            int num = 0;
            for (int i = 0; i < (int)b.Length && b[i] > 0; i++)
            {
                num++;
            }
            byte[] numArray = new byte[num];
            for (int i = 0; i < num && b[i] > 0; i++)
            {
                numArray[i] = b[i];
            }

            return Encoding.ASCII.GetString(numArray);
        }

        public static Byte[] StringToBytes(string str, string lang)
        {
            Byte[] bytes = new Byte[0];
            if (str == null || str.Length == 0)
                return bytes;
            if (lang == "Chinese")
                bytes = Encoding.GetEncoding("CP936").GetBytes(str);
            else if (lang == "Arabic")
                bytes = Encoding.GetEncoding("Windows-1256").GetBytes(str);
            else if (lang == "Korean")
                bytes = Encoding.GetEncoding("ks_c_5601-1987").GetBytes(str);
            else if (lang == "French" || lang == "German" || lang == "Italian" || lang == "Spanish" || lang == "Portuguese")
                bytes = Encoding.GetEncoding("Windows-1252").GetBytes(str);
            else if (lang == "English")
                bytes = Encoding.GetEncoding("ASCII").GetBytes(str);
            else if (lang == "Polish")
                bytes = Encoding.GetEncoding("Windows-1250").GetBytes(str);
            else if (lang == "Russian")
                bytes = Encoding.GetEncoding("Windows-1251").GetBytes(str);
            else if (lang == "Japanese")
                bytes = Encoding.GetEncoding("Shift-JIS").GetBytes(str);
            else if (lang == "Turkish")
                bytes = Encoding.GetEncoding("Windows-1254").GetBytes(str);

            return bytes;
        }

        public static Byte[] StringToBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static void SwapChars(ref Byte[] pHash)
        {
            if (pHash.Length > 4)
            {
                double strlength;

                strlength = (float)pHash.Length;
                double off = strlength * 0.6600000262260437;
                Byte pb = (Byte)off;
                Byte t = pHash[pb];
                pHash[pb] = pHash[0];
                pHash[0] = t;

                off = strlength * 0.3300000131130219;
                pb = (Byte)off;
                t = pHash[pb];
                pHash[pb] = pHash[1];
                pHash[1] = t;
            }
        }

        public static Byte GetAddChar(Byte[] pHash, Byte[] Key)
        {
            UInt32 var1;
            UInt32 var2;

            var1 = 0;
            var2 = 0;

            Byte strlength = Convert.ToByte(pHash.Length);
            if (strlength != 0)
            {
                while (var2 < strlength)
                {
                    var1 += (Byte)pHash[var2]; var2++;
                }
            }

            Byte index = Convert.ToByte(var1 % 84);
            return Key[index];
        }

        public static Byte GetXorIndex(Byte val, Byte[] Key)
        {
            for (int i = 0; i < Key.Length; ++i)
            {
                if (Key[i] == val)
                    return (Byte)i;
            }
            return 0xff;
        }
    }

    // code by glandu2
    class Scramble
    {
        private static ScrambleMap sc_map = new ScrambleMap();
        public static int BitsScramble(int c)
        {
            int result;
            uint v2;

            result = 0;
            v2 = 0;
            do
            {
                if ((((uint)1 << (int)v2) & c) != 0)
                    result |= 1 << sc_map.Map[v2];
                ++v2;
            }
            while (v2 < 32);
            return result;
        }

        public static int BitsDescramble(int c)
        {
            int result;
            uint v2;

            result = 0;
            v2 = 0;
            do
            {
                if ((((uint)1 << (int)v2) & c) != 0)
                    result |= 1 << sc_map.DMap[v2];
                ++v2;
            }
            while (v2 < 32);
            return result;
        }
    }

    class ScrambleMap
    {
        public ScrambleMap()
        {
            int v3;
            int i;
            byte v5;

            for (i = 0; i < 32; ++i)
            {
                Map[i] = (byte)i;
            }

            v3 = 3;
            for (i = 0; i < 32; ++i)
            {
                v5 = Map[i];
                if (v3 >= 32)
                    v3 += -32 * (v3 >> 5);
                Map[i] = Map[v3];
                Map[v3] = v5;
                v3 += i + 3;
            }
            for (i = 0; i < 32; ++i)
            {
                DMap[Map[i]] = (byte)i;
            }
        }

        public byte[] Map = new byte[32];
        public byte[] DMap = new byte[32];
    }
}
