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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tbZR = new System.Windows.Forms.TextBox();
            this.tbYR = new System.Windows.Forms.TextBox();
            this.tbXR = new System.Windows.Forms.TextBox();
            this.tbFadeMargin = new System.Windows.Forms.TextBox();
            this.tbAntenaGain = new System.Windows.Forms.TextBox();
            this.tbTransPower = new System.Windows.Forms.TextBox();
            this.tbSsid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouters)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(791, 401);
            this.splitContainer1.SplitterDistance = 166;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tbZR);
            this.groupBox2.Controls.Add(this.tbYR);
            this.groupBox2.Controls.Add(this.tbXR);
            this.groupBox2.Controls.Add(this.tbFadeMargin);
            this.groupBox2.Controls.Add(this.tbAntenaGain);
            this.groupBox2.Controls.Add(this.tbTransPower);
            this.groupBox2.Controls.Add(this.tbSsid);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(204, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Routery";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(499, 138);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Zapisz";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Nowe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbZR
            // 
            this.tbZR.Location = new System.Drawing.Point(363, 104);
            this.tbZR.Name = "tbZR";
            this.tbZR.Size = new System.Drawing.Size(211, 20);
            this.tbZR.TabIndex = 14;
            // 
            // tbYR
            // 
            this.tbYR.Location = new System.Drawing.Point(363, 78);
            this.tbYR.Name = "tbYR";
            this.tbYR.Size = new System.Drawing.Size(211, 20);
            this.tbYR.TabIndex = 13;
            // 
            // tbXR
            // 
            this.tbXR.Location = new System.Drawing.Point(363, 52);
            this.tbXR.Name = "tbXR";
            this.tbXR.Size = new System.Drawing.Size(211, 20);
            this.tbXR.TabIndex = 12;
            // 
            // tbFadeMargin
            // 
            this.tbFadeMargin.Location = new System.Drawing.Point(99, 104);
            this.tbFadeMargin.Name = "tbFadeMargin";
            this.tbFadeMargin.Size = new System.Drawing.Size(235, 20);
            this.tbFadeMargin.TabIndex = 11;
            // 
            // tbAntenaGain
            // 
            this.tbAntenaGain.Location = new System.Drawing.Point(99, 78);
            this.tbAntenaGain.Name = "tbAntenaGain";
            this.tbAntenaGain.Size = new System.Drawing.Size(235, 20);
            this.tbAntenaGain.TabIndex = 10;
            // 
            // tbTransPower
            // 
            this.tbTransPower.Location = new System.Drawing.Point(99, 52);
            this.tbTransPower.Name = "tbTransPower";
            this.tbTransPower.Size = new System.Drawing.Size(235, 20);
            this.tbTransPower.TabIndex = 9;
            // 
            // tbSsid
            // 
            this.tbSsid.Location = new System.Drawing.Point(99, 26);
            this.tbSsid.Name = "tbSsid";
            this.tbSsid.Size = new System.Drawing.Size(235, 20);
            this.tbSsid.TabIndex = 8;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fade margin:";
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
            this.groupBox1.Size = new System.Drawing.Size(198, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wielkość mapy";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(9, 86);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(183, 20);
            this.tbY.TabIndex = 4;
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
            this.tbX.Size = new System.Drawing.Size(183, 20);
            this.tbX.TabIndex = 2;
            // 
            // btnSaveMapSize
            // 
            this.btnSaveMapSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveMapSize.Location = new System.Drawing.Point(123, 140);
            this.btnSaveMapSize.Name = "btnSaveMapSize";
            this.btnSaveMapSize.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMapSize.TabIndex = 1;
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
            this.dgvRouters.Size = new System.Drawing.Size(791, 231);
            this.dgvRouters.TabIndex = 0;
            this.dgvRouters.SelectionChanged += new System.EventHandler(this.dgvRouters_SelectionChanged);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 401);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(807, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(807, 440);
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
        private System.Windows.Forms.TextBox tbFadeMargin;
        private System.Windows.Forms.TextBox tbAntenaGain;
        private System.Windows.Forms.TextBox tbTransPower;
        private System.Windows.Forms.TextBox tbSsid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}