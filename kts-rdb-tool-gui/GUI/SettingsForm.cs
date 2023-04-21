using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kts_rdb_tool_gui.GUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            hostTB.Text = Settings.Default.host;
            databaseTB.Text = Settings.Default.db;
            usernameTB.Text = Settings.Default.username;
            passwordTB.Text = Settings.Default.password;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Settings.Default.host = hostTB.Text;
            Settings.Default.db = databaseTB.Text;
            Settings.Default.username = usernameTB.Text;
            Settings.Default.password = passwordTB.Text;
            Settings.Default.Save();
            Settings.Default.Reload();
            Close();
        }
    }
}
