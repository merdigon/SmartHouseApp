namespace SmartHouseApp.Client.Views
{
    partial class ConfigurationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.cbRouterCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbZR = new System.Windows.Forms.TextBox();
            this.tbYR = new System.Windows.Forms.TextBox();
            this.tbXR = new System.Windows.Forms.TextBox();
            this.tbAntenaGain = new System.Windows.Forms.TextBox();
            this.tbTransPower = new System.Windows.Forms.TextBox();
            this.tbSsid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.btnSaveMapSize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRouters = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.gBCategory = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lvDeviceItemCategories = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefreshUsers = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveUsers = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteUser = new System.Windows.Forms.ToolStripButton();
            this.ilDeviceImages = new System.Windows.Forms.ImageList(this.components);
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisibleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouters)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvRouters);
            this.splitContainer1.Size = new System.Drawing.Size(777, 417);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbWeight);
            this.groupBox2.Controls.Add(this.cbRouterCategory);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbZR);
            this.groupBox2.Controls.Add(this.tbYR);
            this.groupBox2.Controls.Add(this.tbXR);
            this.groupBox2.Controls.Add(this.tbAntenaGain);
            this.groupBox2.Controls.Add(this.tbTransPower);
            this.groupBox2.Controls.Add(this.tbSsid);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(190, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 221);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Routery";
            // 
            // tbWeight
            // 
            this.tbWeight.Location = new System.Drawing.Point(99, 104);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(235, 20);
            this.tbWeight.TabIndex = 6;
            // 
            // cbRouterCategory
            // 
            this.cbRouterCategory.FormattingEnabled = true;
            this.cbRouterCategory.Location = new System.Drawing.Point(99, 130);
            this.cbRouterCategory.Name = "cbRouterCategory";
            this.cbRouterCategory.Size = new System.Drawing.Size(235, 21);
            this.cbRouterCategory.TabIndex = 7;
            this.cbRouterCategory.SelectedIndexChanged += new System.EventHandler(this.cbRouterCategory_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Waga:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Rodzaj:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Zapisz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 167);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Nowe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbZR
            // 
            this.tbZR.Location = new System.Drawing.Point(363, 104);
            this.tbZR.Name = "tbZR";
            this.tbZR.Size = new System.Drawing.Size(211, 20);
            this.tbZR.TabIndex = 10;
            // 
            // tbYR
            // 
            this.tbYR.Location = new System.Drawing.Point(363, 78);
            this.tbYR.Name = "tbYR";
            this.tbYR.Size = new System.Drawing.Size(211, 20);
            this.tbYR.TabIndex = 9;
            // 
            // tbXR
            // 
            this.tbXR.Location = new System.Drawing.Point(363, 52);
            this.tbXR.Name = "tbXR";
            this.tbXR.Size = new System.Drawing.Size(211, 20);
            this.tbXR.TabIndex = 8;
            // 
            // tbAntenaGain
            // 
            this.tbAntenaGain.Location = new System.Drawing.Point(99, 78);
            this.tbAntenaGain.Name = "tbAntenaGain";
            this.tbAntenaGain.Size = new System.Drawing.Size(235, 20);
            this.tbAntenaGain.TabIndex = 5;
            // 
            // tbTransPower
            // 
            this.tbTransPower.Location = new System.Drawing.Point(99, 52);
            this.tbTransPower.Name = "tbTransPower";
            this.tbTransPower.Size = new System.Drawing.Size(235, 20);
            this.tbTransPower.TabIndex = 4;
            // 
            // tbSsid
            // 
            this.tbSsid.Location = new System.Drawing.Point(99, 26);
            this.tbSsid.Name = "tbSsid";
            this.tbSsid.Size = new System.Drawing.Size(235, 20);
            this.tbSsid.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(340, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(340, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Lokalizacja:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Zysk anteny:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Siła transmitera:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "SSID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbY);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbX);
            this.groupBox1.Controls.Add(this.btnSaveMapSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 221);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wielkość mapy";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(9, 86);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(175, 20);
            this.tbY.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(9, 42);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(175, 20);
            this.tbX.TabIndex = 1;
            // 
            // btnSaveMapSize
            // 
            this.btnSaveMapSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMapSize.Location = new System.Drawing.Point(109, 195);
            this.btnSaveMapSize.Name = "btnSaveMapSize";
            this.btnSaveMapSize.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMapSize.TabIndex = 14;
            this.btnSaveMapSize.Text = "Zapisz";
            this.btnSaveMapSize.UseVisualStyleBackColor = true;
            this.btnSaveMapSize.Click += new System.EventHandler(this.btnSaveMapSize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X";
            // 
            // dgvRouters
            // 
            this.dgvRouters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRouters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRouters.Location = new System.Drawing.Point(0, 0);
            this.dgvRouters.MultiSelect = false;
            this.dgvRouters.Name = "dgvRouters";
            this.dgvRouters.ReadOnly = true;
            this.dgvRouters.Size = new System.Drawing.Size(777, 192);
            this.dgvRouters.TabIndex = 0;
            this.dgvRouters.SelectionChanged += new System.EventHandler(this.dgvRouters_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(791, 449);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(783, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lokalizacja";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.gBCategory);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.lvDeviceItemCategories);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(783, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Zarządzanie sprzętem";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button6.AutoSize = true;
            this.button6.Image = global::SmartHouseApp.Client.Properties.Resources.Save_as_48px;
            this.button6.Location = new System.Drawing.Point(735, 385);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 30);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // gBCategory
            // 
            this.gBCategory.Location = new System.Drawing.Point(384, 34);
            this.gBCategory.Name = "gBCategory";
            this.gBCategory.Size = new System.Drawing.Size(381, 345);
            this.gBCategory.TabIndex = 7;
            this.gBCategory.TabStop = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button4.AutoSize = true;
            this.button4.Image = global::SmartHouseApp.Client.Properties.Resources.Delete_48px;
            this.button4.Location = new System.Drawing.Point(333, 385);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 30);
            this.button4.TabIndex = 6;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(192, 34);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(171, 345);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button5.AutoSize = true;
            this.button5.Image = global::SmartHouseApp.Client.Properties.Resources.Plus_48px;
            this.button5.Location = new System.Drawing.Point(297, 385);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 30);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SmartHouseApp.Client.Properties.Resources.Forward_48px;
            this.pictureBox1.Location = new System.Drawing.Point(158, 197);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lvDeviceItemCategories
            // 
            this.lvDeviceItemCategories.FullRowSelect = true;
            this.lvDeviceItemCategories.Location = new System.Drawing.Point(8, 34);
            this.lvDeviceItemCategories.MultiSelect = false;
            this.lvDeviceItemCategories.Name = "lvDeviceItemCategories";
            this.lvDeviceItemCategories.Size = new System.Drawing.Size(144, 345);
            this.lvDeviceItemCategories.TabIndex = 0;
            this.lvDeviceItemCategories.UseCompatibleStateImageBehavior = false;
            this.lvDeviceItemCategories.SelectedIndexChanged += new System.EventHandler(this.lvDeviceItemCategories_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvUsers);
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(783, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Użytkownicy";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.VisibleName,
            this.Mac,
            this.Weight});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(3, 28);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(777, 392);
            this.dgvUsers.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefreshUsers,
            this.tsbSaveUsers,
            this.tsbDeleteUser});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(777, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefreshUsers
            // 
            this.tsbRefreshUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshUsers.Image = global::SmartHouseApp.Client.Properties.Resources.Restart_48px;
            this.tsbRefreshUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshUsers.Name = "tsbRefreshUsers";
            this.tsbRefreshUsers.Size = new System.Drawing.Size(23, 22);
            this.tsbRefreshUsers.Text = "Pobierz";
            this.tsbRefreshUsers.Click += new System.EventHandler(this.tsbRefreshUsers_Click);
            // 
            // tsbSaveUsers
            // 
            this.tsbSaveUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveUsers.Image = global::SmartHouseApp.Client.Properties.Resources.Save_as_48px;
            this.tsbSaveUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveUsers.Name = "tsbSaveUsers";
            this.tsbSaveUsers.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveUsers.Text = "Zapisz";
            this.tsbSaveUsers.Click += new System.EventHandler(this.tsbSaveUsers_Click);
            // 
            // tsbDeleteUser
            // 
            this.tsbDeleteUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteUser.Image = global::SmartHouseApp.Client.Properties.Resources.Delete_48px;
            this.tsbDeleteUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteUser.Name = "tsbDeleteUser";
            this.tsbDeleteUser.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteUser.Text = "Usuń";
            this.tsbDeleteUser.Click += new System.EventHandler(this.tsbDeleteUser_Click);
            // 
            // ilDeviceImages
            // 
            this.ilDeviceImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilDeviceImages.ImageSize = new System.Drawing.Size(16, 16);
            this.ilDeviceImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // VisibleName
            // 
            this.VisibleName.DataPropertyName = "VisibleName";
            this.VisibleName.HeaderText = "Nazwa użytkownika";
            this.VisibleName.Name = "VisibleName";
            // 
            // Mac
            // 
            this.Mac.DataPropertyName = "Mac";
            this.Mac.HeaderText = "Nazwa Mac";
            this.Mac.Name = "Mac";
            this.Mac.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            this.Weight.HeaderText = "Waga użytkownika";
            this.Weight.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.Weight.Name = "Weight";
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 449);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(807, 488);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(807, 488);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouters)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Button btnSaveMapSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRouters;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbZR;
        private System.Windows.Forms.TextBox tbYR;
        private System.Windows.Forms.TextBox tbXR;
        private System.Windows.Forms.TextBox tbAntenaGain;
        private System.Windows.Forms.TextBox tbTransPower;
        private System.Windows.Forms.TextBox tbSsid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvDeviceItemCategories;
        private System.Windows.Forms.ImageList ilDeviceImages;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox gBCategory;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.ComboBox cbRouterCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveUsers;
        private System.Windows.Forms.ToolStripButton tsbDeleteUser;
        private System.Windows.Forms.ToolStripButton tsbRefreshUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisibleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mac;
        private System.Windows.Forms.DataGridViewComboBoxColumn Weight;
    }
}