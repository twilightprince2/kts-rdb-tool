namespace kts_rdb_tool_gui.GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGrid = new DataGridView();
            menuStrip1 = new MenuStrip();
            configurationToolStripMenuItem = new ToolStripMenuItem();
            loadStructToolStripMenuItem = new ToolStripMenuItem();
            importDataToolStripMenuItem = new ToolStripMenuItem();
            importFromRDBToolStripMenuItem = new ToolStripMenuItem();
            importFromDatabaseToolStripMenuItem = new ToolStripMenuItem();
            exportDataToolStripMenuItem = new ToolStripMenuItem();
            exportRDBToolStripMenuItem = new ToolStripMenuItem();
            exportSQLToolStripMenuItem = new ToolStripMenuItem();
            exportCSVToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            statusStrip = new StatusStrip();
            saveFileDialog = new SaveFileDialog();
            toolStripStatusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            menuStrip1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGrid
            // 
            dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.Location = new Point(0, 24);
            dataGrid.Name = "dataGrid";
            dataGrid.RowTemplate.Height = 25;
            dataGrid.Size = new Size(1044, 597);
            dataGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { configurationToolStripMenuItem, loadStructToolStripMenuItem, importDataToolStripMenuItem, exportDataToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1044, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            configurationToolStripMenuItem.Size = new Size(93, 20);
            configurationToolStripMenuItem.Text = "Configuration";
            configurationToolStripMenuItem.Click += configurationToolStripMenuItem_Click;
            // 
            // loadStructToolStripMenuItem
            // 
            loadStructToolStripMenuItem.Name = "loadStructToolStripMenuItem";
            loadStructToolStripMenuItem.Size = new Size(79, 20);
            loadStructToolStripMenuItem.Text = "Load Struct";
            // 
            // importDataToolStripMenuItem
            // 
            importDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importFromRDBToolStripMenuItem, importFromDatabaseToolStripMenuItem });
            importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            importDataToolStripMenuItem.Size = new Size(82, 20);
            importDataToolStripMenuItem.Text = "Import Data";
            // 
            // importFromRDBToolStripMenuItem
            // 
            importFromRDBToolStripMenuItem.Name = "importFromRDBToolStripMenuItem";
            importFromRDBToolStripMenuItem.Size = new Size(190, 22);
            importFromRDBToolStripMenuItem.Text = "Import from RDB";
            importFromRDBToolStripMenuItem.Click += importFromRDBToolStripMenuItem_Click;
            // 
            // importFromDatabaseToolStripMenuItem
            // 
            importFromDatabaseToolStripMenuItem.Name = "importFromDatabaseToolStripMenuItem";
            importFromDatabaseToolStripMenuItem.Size = new Size(190, 22);
            importFromDatabaseToolStripMenuItem.Text = "Import from Database";
            importFromDatabaseToolStripMenuItem.Click += importFromDatabaseToolStripMenuItem_Click;
            // 
            // exportDataToolStripMenuItem
            // 
            exportDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportRDBToolStripMenuItem, exportSQLToolStripMenuItem, exportCSVToolStripMenuItem });
            exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            exportDataToolStripMenuItem.Size = new Size(79, 20);
            exportDataToolStripMenuItem.Text = "Export Data";
            // 
            // exportRDBToolStripMenuItem
            // 
            exportRDBToolStripMenuItem.Name = "exportRDBToolStripMenuItem";
            exportRDBToolStripMenuItem.Size = new Size(146, 22);
            exportRDBToolStripMenuItem.Text = "Export to RDB";
            exportRDBToolStripMenuItem.Click += exportRDBToolStripMenuItem_Click;
            // 
            // exportSQLToolStripMenuItem
            // 
            exportSQLToolStripMenuItem.Name = "exportSQLToolStripMenuItem";
            exportSQLToolStripMenuItem.Size = new Size(146, 22);
            exportSQLToolStripMenuItem.Text = "Export to SQL";
            exportSQLToolStripMenuItem.Click += exportSQLToolStripMenuItem_Click;
            // 
            // exportCSVToolStripMenuItem
            // 
            exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            exportCSVToolStripMenuItem.Size = new Size(146, 22);
            exportCSVToolStripMenuItem.Text = "Export to CSV";
            exportCSVToolStripMenuItem.Click += exportCSVToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 599);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1044, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 621);
            Controls.Add(statusStrip);
            Controls.Add(dataGrid);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGrid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem configurationToolStripMenuItem;
        private ToolStripMenuItem loadStructToolStripMenuItem;
        private ToolStripMenuItem importDataToolStripMenuItem;
        private ToolStripMenuItem importFromRDBToolStripMenuItem;
        private ToolStripMenuItem importFromDatabaseToolStripMenuItem;
        private ToolStripMenuItem exportDataToolStripMenuItem;
        private ToolStripMenuItem exportRDBToolStripMenuItem;
        private ToolStripMenuItem exportSQLToolStripMenuItem;
        private ToolStripMenuItem exportCSVToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private OpenFileDialog openFileDialog;
        private StatusStrip statusStrip;
        private SaveFileDialog saveFileDialog;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
}