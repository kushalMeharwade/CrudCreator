namespace CrudCreator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.ddlTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlDatabse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioGroup = new System.Windows.Forms.RadioButton();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.radioNormal = new System.Windows.Forms.RadioButton();
            this.radioListItem = new System.Windows.Forms.RadioButton();
            this.radioFloating = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnList = new System.Windows.Forms.CheckedListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.requiredList = new System.Windows.Forms.CheckedListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.primaryList = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.repeaterList = new System.Windows.Forms.CheckedListBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkRptItems = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fileUploadList = new System.Windows.Forms.CheckedListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ddlList = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtServer);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.ddlTable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ddlDatabse);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 899);
            this.panel1.TabIndex = 0;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(27, 83);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(288, 39);
            this.txtServer.TabIndex = 8;
            // 
            // btnConnect
            // 
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnConnect.Location = new System.Drawing.Point(27, 139);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(288, 42);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoad.Location = new System.Drawing.Point(26, 460);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(288, 44);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ddlTable
            // 
            this.ddlTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTable.FormattingEnabled = true;
            this.ddlTable.Location = new System.Drawing.Point(26, 372);
            this.ddlTable.Name = "ddlTable";
            this.ddlTable.Size = new System.Drawing.Size(288, 40);
            this.ddlTable.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AllowDrop = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Table List";
            // 
            // ddlDatabse
            // 
            this.ddlDatabse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabse.FormattingEnabled = true;
            this.ddlDatabse.Location = new System.Drawing.Point(27, 257);
            this.ddlDatabse.Name = "ddlDatabse";
            this.ddlDatabse.Size = new System.Drawing.Size(288, 40);
            this.ddlDatabse.TabIndex = 3;
            this.ddlDatabse.SelectedIndexChanged += new System.EventHandler(this.ddlDatabse_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(1);
            this.label1.Size = new System.Drawing.Size(125, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server List";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chkRptItems);
            this.panel3.Controls.Add(this.chkSelectAll);
            this.panel3.Controls.Add(this.radioGroup);
            this.panel3.Controls.Add(this.btnGenerate);
            this.panel3.Controls.Add(this.radioNormal);
            this.panel3.Controls.Add(this.radioListItem);
            this.panel3.Controls.Add(this.radioFloating);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(343, 771);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1961, 128);
            this.panel3.TabIndex = 2;
            // 
            // radioGroup
            // 
            this.radioGroup.AutoSize = true;
            this.radioGroup.Location = new System.Drawing.Point(622, 18);
            this.radioGroup.Name = "radioGroup";
            this.radioGroup.Size = new System.Drawing.Size(175, 36);
            this.radioGroup.TabIndex = 4;
            this.radioGroup.Text = "Group-Form";
            this.radioGroup.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGenerate.Location = new System.Drawing.Point(18, 67);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(781, 49);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // radioNormal
            // 
            this.radioNormal.AutoSize = true;
            this.radioNormal.Location = new System.Drawing.Point(423, 18);
            this.radioNormal.Name = "radioNormal";
            this.radioNormal.Size = new System.Drawing.Size(175, 36);
            this.radioNormal.TabIndex = 2;
            this.radioNormal.Text = "outine Form";
            this.radioNormal.UseVisualStyleBackColor = true;
            // 
            // radioListItem
            // 
            this.radioListItem.AutoSize = true;
            this.radioListItem.Location = new System.Drawing.Point(224, 18);
            this.radioListItem.Name = "radioListItem";
            this.radioListItem.Size = new System.Drawing.Size(199, 36);
            this.radioListItem.TabIndex = 1;
            this.radioListItem.Text = "List-Item Form";
            this.radioListItem.UseVisualStyleBackColor = true;
            // 
            // radioFloating
            // 
            this.radioFloating.AutoSize = true;
            this.radioFloating.Checked = true;
            this.radioFloating.Location = new System.Drawing.Point(18, 18);
            this.radioFloating.Name = "radioFloating";
            this.radioFloating.Size = new System.Drawing.Size(195, 36);
            this.radioFloating.TabIndex = 0;
            this.radioFloating.TabStop = true;
            this.radioFloating.Text = "Floating-Form";
            this.radioFloating.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(343, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 771);
            this.panel4.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.columnList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 767);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Column List";
            // 
            // columnList
            // 
            this.columnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnList.FormattingEnabled = true;
            this.columnList.Location = new System.Drawing.Point(3, 35);
            this.columnList.Name = "columnList";
            this.columnList.Size = new System.Drawing.Size(262, 729);
            this.columnList.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(615, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(244, 771);
            this.panel5.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.requiredList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.Color.LemonChiffon;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 769);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "requiredList";
            // 
            // requiredList
            // 
            this.requiredList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requiredList.FormattingEnabled = true;
            this.requiredList.Location = new System.Drawing.Point(3, 35);
            this.requiredList.Name = "requiredList";
            this.requiredList.Size = new System.Drawing.Size(236, 731);
            this.requiredList.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.groupBox3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(859, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(235, 771);
            this.panel6.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.primaryList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.Color.LemonChiffon;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 767);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "primaryList";
            // 
            // primaryList
            // 
            this.primaryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.primaryList.FormattingEnabled = true;
            this.primaryList.Location = new System.Drawing.Point(3, 35);
            this.primaryList.Name = "primaryList";
            this.primaryList.Size = new System.Drawing.Size(225, 729);
            this.primaryList.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.repeaterList);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.ForeColor = System.Drawing.Color.LemonChiffon;
            this.groupBox4.Location = new System.Drawing.Point(1094, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(280, 771);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Repeater List";
            // 
            // repeaterList
            // 
            this.repeaterList.Dock = System.Windows.Forms.DockStyle.Left;
            this.repeaterList.FormattingEnabled = true;
            this.repeaterList.Location = new System.Drawing.Point(3, 35);
            this.repeaterList.Name = "repeaterList";
            this.repeaterList.Size = new System.Drawing.Size(274, 733);
            this.repeaterList.TabIndex = 0;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(1302, 4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(286, 36);
            this.chkSelectAll.TabIndex = 5;
            this.chkSelectAll.Text = "SELECT ALL COLUMNS";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkRptItems
            // 
            this.chkRptItems.AutoSize = true;
            this.chkRptItems.Location = new System.Drawing.Point(1604, 4);
            this.chkRptItems.Name = "chkRptItems";
            this.chkRptItems.Size = new System.Drawing.Size(350, 36);
            this.chkRptItems.TabIndex = 6;
            this.chkRptItems.Text = "SELECT ALL REPEATER ITEMS";
            this.chkRptItems.UseVisualStyleBackColor = true;
            this.chkRptItems.CheckedChanged += new System.EventHandler(this.chkRptItems_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(1374, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 771);
            this.panel2.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.fileUploadList);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.ForeColor = System.Drawing.Color.NavajoWhite;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(336, 771);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "File Upload";
            // 
            // fileUploadList
            // 
            this.fileUploadList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileUploadList.FormattingEnabled = true;
            this.fileUploadList.Location = new System.Drawing.Point(3, 35);
            this.fileUploadList.Name = "fileUploadList";
            this.fileUploadList.Size = new System.Drawing.Size(330, 733);
            this.fileUploadList.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(1710, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(594, 771);
            this.panel7.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ddlList);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.ForeColor = System.Drawing.Color.NavajoWhite;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(594, 771);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "DropDown List";
            // 
            // ddlList
            // 
            this.ddlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ddlList.FormattingEnabled = true;
            this.ddlList.Location = new System.Drawing.Point(3, 35);
            this.ddlList.Name = "ddlList";
            this.ddlList.Size = new System.Drawing.Size(588, 733);
            this.ddlList.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2304, 899);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Crud Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox ddlTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlDatabse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton radioGroup;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton radioNormal;
        private System.Windows.Forms.RadioButton radioListItem;
        private System.Windows.Forms.RadioButton radioFloating;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox columnList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox requiredList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox primaryList;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox repeaterList;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.CheckBox chkRptItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox fileUploadList;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox ddlList;
    }
}

