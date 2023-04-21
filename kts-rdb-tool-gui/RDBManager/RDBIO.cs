using System.Buffers;
using System.Globalization;
using KtsRdbTool.Extensions;

namespace KtsRdbTool.RDBManager
{
    public class RDBIO
    {
        public string Path { get; set; }
        public byte[] Bytes { get; set; }
        public int ReadIndex { get; set; }
        public MemoryStream Stream { get; set; }
        public BinaryWriter Writer { get; set; }

        public RDBIO(string path)
        {
            Path = path;
            if (File.Exists(Path))
                Bytes = File.ReadAllBytes(path);
            ReadIndex = 0;
            Stream = new MemoryStream();
            Writer = new BinaryWriter(Stream);
        }

        // TODO: test binary reader and writer
        public int[] ReadBinary(int count)
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(1).ToArray();
            ReadIndex += 1;
            int[] binary = new int[count];
            string bin = RDBCommon.Reverse(Convert.ToString(bytes[0], 2));
            for (int i = 0; i < count; i++)
                binary[i] = bin[i];
            return binary;
        }

        public void WriteBinary(string val)
        {
            Writer.Write(Convert.ToByte(Convert.ToInt32(RDBCommon.Reverse(val), 2)));
        }

        public void WriteBytes(int length)
        {
            Writer.Write(new Byte[length]);
        }

        public int ReadBit()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(1).ToArray();
            ReadIndex += 1;
            return bytes[0] == 0 ? 0 : 1;
        }

        public void WriteBit(string val)
        {
            Writer.Write(Convert.ToByte(Convert.ToInt32(val) == 0 ? 0 : 255));
        }

        public byte ReadUInt8()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(1).ToArray();
            ReadIndex += 1;
            return Convert.ToByte(bytes[0]);
        }

        public void WriteUInt8(string val)
        {
            Writer.Write(Convert.ToByte(val));
        }

        public byte ReadInt8()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(1).ToArray();
            ReadIndex += 1;
            return bytes[0];
        }

        public void WriteInt8(string val)
        {
            Writer.Write(Convert.ToByte(val));
        }

        public UInt16 ReadUInt16()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(2).ToArray();
            ReadIndex += 2;
            return BitConverter.ToUInt16(bytes);
        }

        public void WriteUInt16(string val)
        {
            Writer.Write(Convert.ToUInt16(val));
        }

        public Int16 ReadInt16()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(2).ToArray();
            ReadIndex += 2;
            return BitConverter.ToInt16(bytes);
        }

        public void WriteInt16(string val)
        {
            Writer.Write(Convert.ToInt16(val));
        }

        public UInt32 ReadUInt32()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(4).ToArray();
            ReadIndex += 4;
            return BitConverter.ToUInt32(bytes);
        }

        public void WriteUInt32(string val)
        {
            Writer.Write(Convert.ToUInt32(val));
        }

        public Int32 ReadInt32()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(4).ToArray();
            ReadIndex += 4;
            return BitConverter.ToInt32(bytes);
        }

        public void WriteInt32(string val)
        {
            Writer.Write(Convert.ToInt32(val));
        }

        public UInt64 ReadUInt64()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(8).ToArray();
            ReadIndex += 8;
            return BitConverter.ToUInt64(bytes);
        }

        public void WriteUInt64(string val)
        {
            Writer.Write(Convert.ToUInt64(val));
        }

        public Int64 ReadInt64()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(8).ToArray();
            ReadIndex += 8;
            return BitConverter.ToInt64(bytes);
        }

        public void WriteInt64(string val)
        {
            Writer.Write(Convert.ToInt64(val));
        }

        public Int32 ReadMonId()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(4).ToArray();
            ReadIndex += 4;
            return Scramble.BitsDescramble(BitConverter.ToInt32(bytes, 0));
        }

        public void WriteMonId(string val)
        {
            Writer.Write(Scramble.BitsScramble(Convert.ToInt32(val)));
        }

        public float ReadFloat()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(4).ToArray();
            ReadIndex += 4;
            return (float)Math.Round(BitConverter.ToSingle(bytes, 0), 8);
        }

        public void WriteFloat(string val)
        {
            Writer.Write(Convert.ToSingle(val));
        }

        public double ReadDouble()
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(8).ToArray();
            ReadIndex += 8;
            return Math.Round(BitConverter.ToDouble(bytes, 0), 8);
        }

        public void WriteDouble(string val)
        {
            Writer.Write(Convert.ToDouble(val));
        }

        public DateTime ReadDateTime()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(ReadInt32());
        }

        public void WriteDateTime(string val)
        {
            Writer.Write(Convert.ToInt32((DateTime.ParseExact(val, "yyyyMMddHHmmss", null) - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds));
        }

        public string Readstring(int length, string lang)
        {
            byte[] bytes = Bytes.Skip(ReadIndex).Take(length).ToArray();
            ReadIndex += length;
            return RDBCommon.BytesToString(bytes, lang);
        }

        public void WriteString(string val, string lang)
        {
            Writer.Write(RDBCommon.StringToBytes(val, lang));
        }

        public void WriteString(string val, int length, string lang)
        {
            Writer.Write(RDBCommon.StringToBytes(val, lang));
            WriteBytes(length - val.Length);
        }

        public void WriteFlush()
        {
            using (var fileStream = File.Create(Path))
            {
                Stream.Seek(0, SeekOrigin.Begin);
                Stream.CopyTo(fileStream);
                Stream.Close();
                Writer.Close();
                Writer.Flush();
            }
        }

        // lua mapping functions (for better naming convention)
        public int read_index { get { return ReadIndex; } set { ReadIndex = value; } }
    }
}
