namespace World
{
    partial class frmMain
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.pbWorld = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblZoom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudColors = new System.Windows.Forms.NumericUpDown();
            this.nudBrush = new System.Windows.Forms.NumericUpDown();
            this.nudColumns = new System.Windows.Forms.NumericUpDown();
            this.nudZoom = new System.Windows.Forms.NumericUpDown();
            this.chkASCIIWorld = new System.Windows.Forms.CheckBox();
            this.chkHighContrast = new System.Windows.Forms.CheckBox();
            this.txtWorld = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.nudCities = new System.Windows.Forms.NumericUpDown();
            this.lblCities = new System.Windows.Forms.Label();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdMain = new System.Windows.Forms.SaveFileDialog();
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbWorld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCities)).BeginInit();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(184, 101);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 32);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pbWorld
            // 
            this.pbWorld.InitialImage = null;
            this.pbWorld.Location = new System.Drawing.Point(6, 140);
            this.pbWorld.Name = "pbWorld";
            this.pbWorld.Size = new System.Drawing.Size(200, 200);
            this.pbWorld.TabIndex = 2;
            this.pbWorld.TabStop = false;
            this.pbWorld.MouseHover += new System.EventHandler(this.pbWorld_MouseHover);
            this.pbWorld.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbWorld_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Colors";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(143, 21);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(78, 18);
            this.lblColumns.TabIndex = 7;
            this.lblColumns.Text = "Columns";
            // 
            // lblZoom
            // 
            this.lblZoom.AutoSize = true;
            this.lblZoom.Location = new System.Drawing.Point(173, 53);
            this.lblZoom.Name = "lblZoom";
            this.lblZoom.Size = new System.Drawing.Size(48, 18);
            this.lblZoom.TabIndex = 9;
            this.lblZoom.Text = "Zoom";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Brush";
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(81, 13);
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(47, 26);
            this.nudRows.TabIndex = 13;
            this.nudRows.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudColors
            // 
            this.nudColors.Location = new System.Drawing.Point(81, 45);
            this.nudColors.Name = "nudColors";
            this.nudColors.Size = new System.Drawing.Size(47, 26);
            this.nudColors.TabIndex = 14;
            this.nudColors.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudBrush
            // 
            this.nudBrush.Location = new System.Drawing.Point(81, 77);
            this.nudBrush.Name = "nudBrush";
            this.nudBrush.Size = new System.Drawing.Size(47, 26);
            this.nudBrush.TabIndex = 15;
            this.nudBrush.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudColumns
            // 
            this.nudColumns.Location = new System.Drawing.Point(227, 13);
            this.nudColumns.Name = "nudColumns";
            this.nudColumns.Size = new System.Drawing.Size(47, 26);
            this.nudColumns.TabIndex = 16;
            this.nudColumns.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nudZoom
            // 
            this.nudZoom.Location = new System.Drawing.Point(227, 45);
            this.nudZoom.Name = "nudZoom";
            this.nudZoom.Size = new System.Drawing.Size(47, 26);
            this.nudZoom.TabIndex = 17;
            this.nudZoom.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkASCIIWorld
            // 
            this.chkASCIIWorld.AutoSize = true;
            this.chkASCIIWorld.Location = new System.Drawing.Point(176, 74);
            this.chkASCIIWorld.Name = "chkASCIIWorld";
            this.chkASCIIWorld.Size = new System.Drawing.Size(127, 22);
            this.chkASCIIWorld.TabIndex = 18;
            this.chkASCIIWorld.Text = "Show ASCII";
            this.chkASCIIWorld.UseVisualStyleBackColor = true;
            this.chkASCIIWorld.CheckedChanged += new System.EventHandler(this.chkASCIIWorld_CheckedChanged);
            // 
            // chkHighContrast
            // 
            this.chkHighContrast.AutoSize = true;
            this.chkHighContrast.Location = new System.Drawing.Point(20, 107);
            this.chkHighContrast.Name = "chkHighContrast";
            this.chkHighContrast.Size = new System.Drawing.Size(157, 22);
            this.chkHighContrast.TabIndex = 19;
            this.chkHighContrast.Text = "High Contrast";
            this.chkHighContrast.UseVisualStyleBackColor = true;
            // 
            // txtWorld
            // 
            this.txtWorld.Location = new System.Drawing.Point(6, 392);
            this.txtWorld.Multiline = true;
            this.txtWorld.Name = "txtWorld";
            this.txtWorld.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWorld.Size = new System.Drawing.Size(297, 246);
            this.txtWorld.TabIndex = 1;
            this.txtWorld.WordWrap = false;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(212, 140);
            this.txtCity.Multiline = true;
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCity.Size = new System.Drawing.Size(338, 200);
            this.txtCity.TabIndex = 20;
            this.txtCity.WordWrap = false;
            // 
            // nudCities
            // 
            this.nudCities.Location = new System.Drawing.Point(375, 13);
            this.nudCities.Name = "nudCities";
            this.nudCities.Size = new System.Drawing.Size(47, 26);
            this.nudCities.TabIndex = 22;
            this.nudCities.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblCities
            // 
            this.lblCities.AutoSize = true;
            this.lblCities.Location = new System.Drawing.Point(291, 21);
            this.lblCities.Name = "lblCities";
            this.lblCities.Size = new System.Drawing.Size(68, 18);
            this.lblCities.TabIndex = 21;
            this.lblCities.Text = "Cities";
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(562, 24);
            this.msMain.TabIndex = 23;
            this.msMain.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // sfdMain
            // 
            this.sfdMain.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdMain_FileOk);
            // 
            // ofdMain
            // 
            this.ofdMain.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdMain_FileOk);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 650);
            this.Controls.Add(this.nudCities);
            this.Controls.Add(this.lblCities);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.chkHighContrast);
            this.Controls.Add(this.chkASCIIWorld);
            this.Controls.Add(this.nudZoom);
            this.Controls.Add(this.nudColumns);
            this.Controls.Add(this.nudBrush);
            this.Controls.Add(this.nudColors);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblZoom);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbWorld);
            this.Controls.Add(this.txtWorld);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.msMain);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.Text = "The World";
            ((System.ComponentModel.ISupportInitialize)(this.pbWorld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrush)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCities)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.PictureBox pbWorld;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblZoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudColors;
        private System.Windows.Forms.NumericUpDown nudBrush;
        private System.Windows.Forms.NumericUpDown nudColumns;
        private System.Windows.Forms.NumericUpDown nudZoom;
        private System.Windows.Forms.CheckBox chkASCIIWorld;
        private System.Windows.Forms.CheckBox chkHighContrast;
        private System.Windows.Forms.TextBox txtWorld;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.NumericUpDown nudCities;
        private System.Windows.Forms.Label lblCities;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdMain;
        private System.Windows.Forms.OpenFileDialog ofdMain;
    }
}

