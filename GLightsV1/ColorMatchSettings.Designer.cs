
namespace GLightsV1
{
    partial class ColorMatchSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorMatchSettings));
            this.cmbSelectSide = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barDeadzone = new System.Windows.Forms.TrackBar();
            this.barDeadzoneCurve = new System.Windows.Forms.TrackBar();
            this.lblDeadzone = new System.Windows.Forms.Label();
            this.lblDeadzoneCurve = new System.Windows.Forms.Label();
            this.barSmoothness = new System.Windows.Forms.TrackBar();
            this.lblSmoothness = new System.Windows.Forms.Label();
            this.lblTopHeight = new System.Windows.Forms.Label();
            this.barTopHeight = new System.Windows.Forms.TrackBar();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnResetSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barDeadzone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barDeadzoneCurve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSmoothness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTopHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSelectSide
            // 
            this.cmbSelectSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectSide.FormattingEnabled = true;
            this.cmbSelectSide.Items.AddRange(new object[] {
            "Left",
            "Right"});
            this.cmbSelectSide.Location = new System.Drawing.Point(15, 32);
            this.cmbSelectSide.Name = "cmbSelectSide";
            this.cmbSelectSide.Size = new System.Drawing.Size(71, 21);
            this.cmbSelectSide.TabIndex = 2;
            this.cmbSelectSide.SelectedIndexChanged += new System.EventHandler(this.cmbSelectSide_SelectedIndexChanged);
            this.cmbSelectSide.Enter += new System.EventHandler(this.cmbSelectSide_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Side";
            // 
            // barDeadzone
            // 
            this.barDeadzone.Location = new System.Drawing.Point(16, 76);
            this.barDeadzone.Maximum = 50;
            this.barDeadzone.Name = "barDeadzone";
            this.barDeadzone.Size = new System.Drawing.Size(225, 45);
            this.barDeadzone.TabIndex = 4;
            this.barDeadzone.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barDeadzone.Scroll += new System.EventHandler(this.barDeadzone_Scroll);
            this.barDeadzone.Enter += new System.EventHandler(this.barDeadzone_Enter);
            // 
            // barDeadzoneCurve
            // 
            this.barDeadzoneCurve.Location = new System.Drawing.Point(16, 127);
            this.barDeadzoneCurve.Maximum = 200;
            this.barDeadzoneCurve.Name = "barDeadzoneCurve";
            this.barDeadzoneCurve.Size = new System.Drawing.Size(225, 45);
            this.barDeadzoneCurve.TabIndex = 5;
            this.barDeadzoneCurve.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barDeadzoneCurve.Scroll += new System.EventHandler(this.barDeadzoneCurve_Scroll_1);
            this.barDeadzoneCurve.Enter += new System.EventHandler(this.barDeadzoneCurve_Enter);
            // 
            // lblDeadzone
            // 
            this.lblDeadzone.AutoSize = true;
            this.lblDeadzone.Location = new System.Drawing.Point(12, 60);
            this.lblDeadzone.Name = "lblDeadzone";
            this.lblDeadzone.Size = new System.Drawing.Size(56, 13);
            this.lblDeadzone.TabIndex = 6;
            this.lblDeadzone.Text = "Deadzone";
            // 
            // lblDeadzoneCurve
            // 
            this.lblDeadzoneCurve.AutoSize = true;
            this.lblDeadzoneCurve.Location = new System.Drawing.Point(12, 111);
            this.lblDeadzoneCurve.Name = "lblDeadzoneCurve";
            this.lblDeadzoneCurve.Size = new System.Drawing.Size(87, 13);
            this.lblDeadzoneCurve.TabIndex = 7;
            this.lblDeadzoneCurve.Text = "Deadzone Curve";
            // 
            // barSmoothness
            // 
            this.barSmoothness.Location = new System.Drawing.Point(16, 178);
            this.barSmoothness.Maximum = 100;
            this.barSmoothness.Minimum = 10;
            this.barSmoothness.Name = "barSmoothness";
            this.barSmoothness.Size = new System.Drawing.Size(225, 45);
            this.barSmoothness.TabIndex = 8;
            this.barSmoothness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barSmoothness.Value = 10;
            this.barSmoothness.Scroll += new System.EventHandler(this.barSmoothness_Scroll);
            this.barSmoothness.Enter += new System.EventHandler(this.barSmoothness_Enter);
            // 
            // lblSmoothness
            // 
            this.lblSmoothness.AutoSize = true;
            this.lblSmoothness.Location = new System.Drawing.Point(13, 162);
            this.lblSmoothness.Name = "lblSmoothness";
            this.lblSmoothness.Size = new System.Drawing.Size(65, 13);
            this.lblSmoothness.TabIndex = 9;
            this.lblSmoothness.Text = "Smoothness";
            // 
            // lblTopHeight
            // 
            this.lblTopHeight.AutoSize = true;
            this.lblTopHeight.Location = new System.Drawing.Point(13, 214);
            this.lblTopHeight.Name = "lblTopHeight";
            this.lblTopHeight.Size = new System.Drawing.Size(60, 13);
            this.lblTopHeight.TabIndex = 10;
            this.lblTopHeight.Text = "Top Height";
            // 
            // barTopHeight
            // 
            this.barTopHeight.Location = new System.Drawing.Point(16, 230);
            this.barTopHeight.Maximum = 500;
            this.barTopHeight.Minimum = 1;
            this.barTopHeight.Name = "barTopHeight";
            this.barTopHeight.Size = new System.Drawing.Size(225, 45);
            this.barTopHeight.TabIndex = 11;
            this.barTopHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barTopHeight.Value = 1;
            this.barTopHeight.Scroll += new System.EventHandler(this.barTopHeight_Scroll);
            this.barTopHeight.Enter += new System.EventHandler(this.barTopHeight_Enter);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 278);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.Location = new System.Drawing.Point(229, 32);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(125, 41);
            this.btnResetSettings.TabIndex = 13;
            this.btnResetSettings.Text = "Reset to recommened settings";
            this.btnResetSettings.UseVisualStyleBackColor = true;
            this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
            // 
            // ColorMatchSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 368);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.barTopHeight);
            this.Controls.Add(this.lblTopHeight);
            this.Controls.Add(this.lblSmoothness);
            this.Controls.Add(this.barSmoothness);
            this.Controls.Add(this.lblDeadzoneCurve);
            this.Controls.Add(this.lblDeadzone);
            this.Controls.Add(this.barDeadzoneCurve);
            this.Controls.Add(this.barDeadzone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSelectSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorMatchSettings";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ColorMatchSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barDeadzone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barDeadzoneCurve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barSmoothness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barTopHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbSelectSide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar barDeadzone;
        private System.Windows.Forms.TrackBar barDeadzoneCurve;
        private System.Windows.Forms.Label lblDeadzone;
        private System.Windows.Forms.Label lblDeadzoneCurve;
        private System.Windows.Forms.TrackBar barSmoothness;
        private System.Windows.Forms.Label lblSmoothness;
        private System.Windows.Forms.Label lblTopHeight;
        private System.Windows.Forms.TrackBar barTopHeight;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnResetSettings;
    }
}