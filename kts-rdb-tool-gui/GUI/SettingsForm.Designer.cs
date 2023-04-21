namespace kts_rdb_tool_gui.GUI
{
    partial class SettingsForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            hostTB = new TextBox();
            databaseTB = new TextBox();
            usernameTB = new TextBox();
            passwordTB = new TextBox();
            saveBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(hostTB, 1, 0);
            tableLayoutPanel1.Controls.Add(databaseTB, 1, 1);
            tableLayoutPanel1.Controls.Add(usernameTB, 1, 2);
            tableLayoutPanel1.Controls.Add(passwordTB, 1, 3);
            tableLayoutPanel1.Controls.Add(saveBtn, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(372, 161);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 32);
            label1.TabIndex = 0;
            label1.Text = "Host";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 32);
            label2.Name = "label2";
            label2.Size = new Size(68, 32);
            label2.TabIndex = 1;
            label2.Text = "DB";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 64);
            label3.Name = "label3";
            label3.Size = new Size(68, 32);
            label3.TabIndex = 2;
            label3.Text = "Username";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 96);
            label4.Name = "label4";
            label4.Size = new Size(68, 32);
            label4.TabIndex = 3;
            label4.Text = "Password";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hostTB
            // 
            hostTB.Dock = DockStyle.Fill;
            hostTB.Location = new Point(77, 3);
            hostTB.Name = "hostTB";
            hostTB.Size = new Size(292, 23);
            hostTB.TabIndex = 4;
            // 
            // databaseTB
            // 
            databaseTB.Dock = DockStyle.Fill;
            databaseTB.Location = new Point(77, 35);
            databaseTB.Name = "databaseTB";
            databaseTB.Size = new Size(292, 23);
            databaseTB.TabIndex = 5;
            // 
            // usernameTB
            // 
            usernameTB.Dock = DockStyle.Fill;
            usernameTB.Location = new Point(77, 67);
            usernameTB.Name = "usernameTB";
            usernameTB.Size = new Size(292, 23);
            usernameTB.TabIndex = 6;
            // 
            // passwordTB
            // 
            passwordTB.Dock = DockStyle.Fill;
            passwordTB.Location = new Point(77, 99);
            passwordTB.Name = "passwordTB";
            passwordTB.PasswordChar = '*';
            passwordTB.Size = new Size(292, 23);
            passwordTB.TabIndex = 7;
            // 
            // saveBtn
            // 
            saveBtn.Dock = DockStyle.Fill;
            saveBtn.Location = new Point(77, 131);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(292, 27);
            saveBtn.TabIndex = 8;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 161);
            Controls.Add(tableLayoutPanel1);
            Name = "SettingsForm";
            Text = "SettingsForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox hostTB;
        private TextBox databaseTB;
        private TextBox usernameTB;
        private TextBox passwordTB;
        private Button saveBtn;
    }
}