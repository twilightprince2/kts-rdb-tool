using KtsRdbTool.RDBManager;

namespace KtsRdbTool.Extensions
{
    public static class RDBIOExt
    {
        public static int[] read_binary(this RDBIO rdb, int count)
        {
            return rdb.ReadBinary(count);
        }

        public static int read_bit(this RDBIO rdb)
        {
            return rdb.ReadBit();
        }

        public static byte read_uint8(this RDBIO rdb)
        {
            return rdb.ReadUInt8();
        }

        public static byte read_int8(this RDBIO rdb)
        {
            return rdb.ReadInt8();
        }

        public static UInt16 read_uint16(this RDBIO rdb)
        {
            return rdb.ReadUInt16();
        }

        public static Int16 read_int16(this RDBIO rdb)
        {
            return rdb.ReadInt16();
        }

        public static UInt32 read_uint32(this RDBIO rdb)
        {
            return rdb.ReadUInt32();
        }

        public static Int32 read_int32(this RDBIO rdb)
        {
            return rdb.ReadInt32();
        }

        public static UInt64 read_uint64(this RDBIO rdb)
        {
            return rdb.ReadUInt64();
        }

        public static Int64 read_int64(this RDBIO rdb)
        {
            return rdb.ReadInt64();
        }

        public static Int32 read_monid(this RDBIO rdb)
        {
            return rdb.ReadMonId();
        }

        public static float read_float(this RDBIO rdb)
        {
            return rdb.ReadFloat();
        }

        public static double read_double(this RDBIO rdb)
        {
            return rdb.ReadDouble();
        }

        public static DateTime read_datetime(this RDBIO rdb)
        {
            return rdb.ReadDateTime();
        }

        public static string read_string(this RDBIO rdb, int length, string lang)
        {
            return rdb.Readstring(length, lang);
        }

        public static void write_binary(this RDBIO rdb, object val)
        {
            rdb.WriteBinary("" + val);
        }

        public static void write_bit(this RDBIO rdb, object val)
        {
            rdb.WriteBit("" + val);
        }

        public static void write_unit8(this RDBIO rdb, object val)
        {
            rdb.WriteUInt8("" + val);
        }

        public static void write_int8(this RDBIO rdb, object val)
        {
            rdb.WriteInt8("" + val);
        }

        public static void write_uint16(this RDBIO rdb, object val)
        {
            rdb.WriteUInt16("" + val);
        }

        public static void write_int16(this RDBIO rdb, object val)
        {
            rdb.WriteInt16("" + val);
        }

        public static void write_uint32(this RDBIO rdb, object val)
        {
            rdb.WriteUInt32("" + val);
        }

        public static void write_int32(this RDBIO rdb, object val)
        {
            rdb.WriteInt32("" + val);
        }

        public static void write_uint64(this RDBIO rdb, object val)
        {
            rdb.WriteUInt64("" + val);
        }

        public static void write_int64(this RDBIO rdb, object val)
        {
            rdb.WriteInt64("" + val);
        }

        public static void write_monid(this RDBIO rdb, object val)
        {
            rdb.WriteMonId("" + val);
        }

        public static void write_float(this RDBIO rdb, object val)
        {
            rdb.WriteFloat("" + val);
        }

        public static void write_double(this RDBIO rdb, object val)
        {
            rdb.WriteDouble("" + val);
        }

        public static void write_datetime(this RDBIO rdb, object val)
        {
            rdb.WriteDateTime("" + val);
        }

        public static void write_string(this RDBIO rdb, object val, object length, object lang)
        {
            if (length == null)
                rdb.WriteString("" + val, "" + lang);
            else
                rdb.WriteString("" + val, int.Parse("" + length), "" + lang);
        }

        public static void write_bytes(this RDBIO rdb, object val)
        {
            rdb.WriteBytes(int.Parse("" + val));
        }
    }
}
