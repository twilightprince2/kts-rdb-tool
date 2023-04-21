using System.Data;
using System.Text;

namespace KtsRdbTool.Extensions
{
    public static class DataTableExt
    {
        public static string ToCsv(this DataTable dataTable)
        {
            StringBuilder sbData = new StringBuilder();

            // Only return Null if there is no structure.
            if (dataTable.Columns.Count == 0)
                return null;

            foreach (var col in dataTable.Columns)
            {
                if (col == null)
                    sbData.Append(",");
                else
                    sbData.Append("\"" + col.ToString().Replace("\"", "\"\"") + "\",");
            }

            sbData.Replace(",", System.Environment.NewLine, sbData.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                    if (column == null)
                        sbData.Append(",");
                    else
                        sbData.Append("\"" + column.ToString().Replace("\"", "\"\"") + "\",");
                sbData.Replace(",", System.Environment.NewLine, sbData.Length - 1, 1);
            }

            return sbData.ToString();
        }

        public static string ToSql(this DataTable dataTable)
        {
            StringBuilder sbData = new StringBuilder();
            string prefix = "INSERT " + dataTable.TableName + " (";

            // Only return Null if there is no structure.
            if (dataTable.Columns.Count == 0)
                return null;

            foreach (DataColumn col in dataTable.Columns)
                prefix += "[" + col.ColumnName + "], ";
            prefix = prefix.Substring(0, prefix.Length - 2) + ") VALUES (";

            foreach (DataRow dr in dataTable.Rows)
            {
                sbData.Append(prefix);
                foreach (var val in dr.ItemArray)
                    sbData.Append("'" + val + "',");
                sbData.Replace(",", ")" + System.Environment.NewLine, sbData.Length - 1, 1);
            }

            return sbData.ToString();
        }

        public static string ToLuaTable(this DataTable dataTable)
        {
            // Only return Null if there is no structure.
            if (dataTable.Columns.Count == 0)
                return "{}";

            StringBuilder sbData = new StringBuilder();
            sbData.Append("{");

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sbData.Append("{");
                DataRow row = dataTable.Rows[i];
                foreach (DataColumn col in dataTable.Columns)
                    sbData.Append(col + "='" + row[col] + "',");

                if (i < dataTable.Rows.Count - 1)
                    sbData.Replace(",", "}," + System.Environment.NewLine, sbData.Length - 1, 1);
                else
                    sbData.Replace(",", "}" + System.Environment.NewLine + "}", sbData.Length - 1, 1);
            }

            return sbData.ToString();
        }
    }
}
