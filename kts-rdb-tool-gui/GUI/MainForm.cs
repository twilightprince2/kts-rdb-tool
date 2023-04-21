using System.Data;
using System.Text;
using KtsRdbTool.Database;
using KtsRdbTool.Extensions;
using KtsRdbTool.RDBManager;
using NLua;

namespace kts_rdb_tool_gui.GUI
{
    public partial class MainForm : Form
    {
        public FileInfo[] Files { get; set; }
        public MSSQLConnection Connection { get; set; }
        public DataTable MasterTable { get; set; }
        public RDBIO RDBFile { get; set; }
        public Lua LuaState { get; set; }

        public MainForm()
        {
            InitializeComponent();
            InitializeConnection();
            LoadLuaFiles();
        }

        public void InitializeConnection()
        {
            if (Settings.Default.username != "")
                Connection = new MSSQLConnection(Settings.Default.host, Settings.Default.username, Settings.Default.password, Settings.Default.db);
            else
                configurationToolStripMenuItem_Click(this, null);
        }

        public void LoadLuaFiles()
        {
            DirectoryInfo d = new DirectoryInfo(Settings.Default.luaPath);
            Files = d.GetFiles("*.lua");

            foreach (FileInfo f in Files)
            {
                var item = new ToolStripMenuItem(f.Name);
                item.Tag = f.FullName;
                item.Click += new EventHandler(luaFileItem_Click);
                loadStructToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void luaFileItem_Click(object sender, EventArgs e)
        {
            String tag = ((ToolStripMenuItem)sender).Tag.ToString();
            LuaState = new Lua();
            LuaState.State.Encoding = Encoding.UTF8;
            LuaState.DoFile(tag);
            toolStripStatusLabel.Text = "Loading lua file " + tag;
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            InitializeConnection();
        }

        private void importFromRDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var path = openFileDialog.FileName;
                RDBFile = new RDBIO(openFileDialog.FileName);
                var onRead = LuaState["on_read"] as LuaFunction;

                // initiating a new table with the needed column names
                LuaTable tbl = (LuaTable)onRead.Call(RDBFile).First();
                LuaTable lColumns = (LuaTable)LuaState["columns"];
                MasterTable = new DataTable("" + LuaState["table_name"]);

                foreach (KeyValuePair<object, object> col in lColumns)
                    MasterTable.Columns.Add(col.Value + "");
                foreach (KeyValuePair<object, object> row in tbl)
                {
                    DataRow nRow = MasterTable.NewRow();
                    foreach (KeyValuePair<object, object> col in (LuaTable)row.Value)
                        nRow["" + col.Key] = col.Value;
                    MasterTable.Rows.Add(nRow);
                }
                dataGrid.DataSource = MasterTable;
                watch.Stop();
                toolStripStatusLabel.Text = "imported data from RDB file in " + watch.ElapsedMilliseconds + "ms";
            }
        }

        private void importFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string query = (string)LuaState["query"];
            MasterTable = Connection.fetchQuery(query);
            MasterTable.TableName = "" + LuaState["table_name"];
            dataGrid.DataSource = MasterTable;
            watch.Stop();
            toolStripStatusLabel.Text = "imported data from database table in " + watch.ElapsedMilliseconds + "ms";
        }

        private void exportRDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                RDBFile = new RDBIO(saveFileDialog.FileName);
                var onWrite = LuaState["on_write"] as NLua.LuaFunction;

                // initiating a new table with the needed column names
                LuaState.DoString("passobj1 = " + MasterTable.ToLuaTable());
                onWrite.Call(RDBFile, LuaState.GetTable("passobj1"));
                Console.WriteLine("written " + MasterTable.Rows.Count + " rows and filled into the rdb file in " + watch.ElapsedMilliseconds + "ms");
                RDBFile.WriteFlush();
                toolStripStatusLabel.Text = "exported data to RDB file in " + watch.ElapsedMilliseconds + "ms";
            }
        }

        private void exportSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                File.AppendAllText(saveFileDialog.FileName, MasterTable.ToSql());
                watch.Stop();
                toolStripStatusLabel.Text = "exported data to SQL file in " + watch.ElapsedMilliseconds + "ms";
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                File.AppendAllText(saveFileDialog.FileName, MasterTable.ToCsv());
                watch.Stop();
                toolStripStatusLabel.Text = "exported data to CSV file in " + watch.ElapsedMilliseconds + "ms";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            var res = about.ShowDialog();
        }
    }
}
