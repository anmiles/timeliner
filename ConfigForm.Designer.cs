using System.Drawing;
using System.Windows.Forms;

namespace Timeliner
{
    partial class ConfigForm
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
            this.txtTimelineStart = new System.Windows.Forms.MaskedTextBox();
            this.checkResetAfterMidnight = new System.Windows.Forms.CheckBox();
            this.groupTimeline = new System.Windows.Forms.GroupBox();
            this.tableTimeline = new System.Windows.Forms.TableLayoutPanel();
            this.numericTimelinePeriods = new System.Windows.Forms.NumericUpDown();
            this.numericTimelinePause = new System.Windows.Forms.NumericUpDown();
            this.numericTimelinePlay = new System.Windows.Forms.NumericUpDown();
            this.labelTimelineStart = new System.Windows.Forms.Label();
            this.labelTimelinePlay = new System.Windows.Forms.Label();
            this.labelTimelinePause = new System.Windows.Forms.Label();
            this.labelTimelinePeriods = new System.Windows.Forms.Label();
            this.groupPhases = new System.Windows.Forms.GroupBox();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.tableSettings = new System.Windows.Forms.TableLayoutPanel();
            this.checkShowAfterMidnight = new System.Windows.Forms.CheckBox();
            this.buttonResetConfig = new System.Windows.Forms.Button();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonApplyTemplorarily = new System.Windows.Forms.Button();
            this.buttonSavePermanently = new System.Windows.Forms.Button();
            this.panelAppearancePosition = new System.Windows.Forms.Panel();
            this.labelAppearancePosition = new System.Windows.Forms.Label();
            this.radioPositionRight = new System.Windows.Forms.RadioButton();
            this.radioPositionLeft = new System.Windows.Forms.RadioButton();
            this.radioPositionBottom = new System.Windows.Forms.RadioButton();
            this.radioPositionTop = new System.Windows.Forms.RadioButton();
            this.panelScreens = new System.Windows.Forms.Panel();
            this.listScreens = new System.Windows.Forms.ListBox();
            this.tableAppearanceBarWidth = new System.Windows.Forms.TableLayoutPanel();
            this.numericAppearanceBarWidth = new System.Windows.Forms.NumericUpDown();
            this.labelAppearanceBarWidth = new System.Windows.Forms.Label();
            this.checkAppearanceIgnoreTaskbar = new System.Windows.Forms.CheckBox();
            this.groupAppearance = new System.Windows.Forms.GroupBox();
            this.groupTimeline.SuspendLayout();
            this.tableTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePlay)).BeginInit();
            this.groupSettings.SuspendLayout();
            this.tableSettings.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.panelAppearancePosition.SuspendLayout();
            this.panelScreens.SuspendLayout();
            this.tableAppearanceBarWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAppearanceBarWidth)).BeginInit();
            this.groupAppearance.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTimelineStart
            // 
            this.txtTimelineStart.Location = new System.Drawing.Point(94, 3);
            this.txtTimelineStart.Mask = "00:00:00";
            this.txtTimelineStart.Name = "txtTimelineStart";
            this.txtTimelineStart.Size = new System.Drawing.Size(51, 20);
            this.txtTimelineStart.TabIndex = 1;
            this.txtTimelineStart.ValidatingType = typeof(System.DateTime);
            // 
            // checkResetAfterMidnight
            // 
            this.checkResetAfterMidnight.AutoSize = true;
            this.checkResetAfterMidnight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkResetAfterMidnight.Location = new System.Drawing.Point(10, 3);
            this.checkResetAfterMidnight.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkResetAfterMidnight.Name = "checkResetAfterMidnight";
            this.checkResetAfterMidnight.Size = new System.Drawing.Size(169, 17);
            this.checkResetAfterMidnight.TabIndex = 2;
            this.checkResetAfterMidnight.Text = "Reset after midnight";
            this.checkResetAfterMidnight.UseVisualStyleBackColor = true;
            // 
            // groupTimeline
            // 
            this.groupTimeline.Controls.Add(this.tableTimeline);
            this.groupTimeline.Location = new System.Drawing.Point(12, 12);
            this.groupTimeline.Name = "groupTimeline";
            this.groupTimeline.Size = new System.Drawing.Size(184, 127);
            this.groupTimeline.TabIndex = 4;
            this.groupTimeline.TabStop = false;
            this.groupTimeline.Text = "Timeline";
            // 
            // tableTimeline
            // 
            this.tableTimeline.BackColor = System.Drawing.Color.Transparent;
            this.tableTimeline.ColumnCount = 2;
            this.tableTimeline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTimeline.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableTimeline.Controls.Add(this.numericTimelinePeriods, 1, 3);
            this.tableTimeline.Controls.Add(this.numericTimelinePause, 1, 2);
            this.tableTimeline.Controls.Add(this.numericTimelinePlay, 1, 1);
            this.tableTimeline.Controls.Add(this.labelTimelineStart, 0, 0);
            this.tableTimeline.Controls.Add(this.labelTimelinePlay, 0, 1);
            this.tableTimeline.Controls.Add(this.labelTimelinePause, 0, 2);
            this.tableTimeline.Controls.Add(this.labelTimelinePeriods, 0, 3);
            this.tableTimeline.Controls.Add(this.txtTimelineStart, 1, 0);
            this.tableTimeline.Location = new System.Drawing.Point(0, 18);
            this.tableTimeline.Name = "tableTimeline";
            this.tableTimeline.RowCount = 4;
            this.tableTimeline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableTimeline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableTimeline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableTimeline.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableTimeline.Size = new System.Drawing.Size(182, 107);
            this.tableTimeline.TabIndex = 2;
            // 
            // numericTimelinePeriods
            // 
            this.numericTimelinePeriods.Location = new System.Drawing.Point(94, 81);
            this.numericTimelinePeriods.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericTimelinePeriods.Name = "numericTimelinePeriods";
            this.numericTimelinePeriods.Size = new System.Drawing.Size(51, 20);
            this.numericTimelinePeriods.TabIndex = 8;
            // 
            // numericTimelinePause
            // 
            this.numericTimelinePause.Location = new System.Drawing.Point(94, 55);
            this.numericTimelinePause.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericTimelinePause.Name = "numericTimelinePause";
            this.numericTimelinePause.Size = new System.Drawing.Size(51, 20);
            this.numericTimelinePause.TabIndex = 7;
            // 
            // numericTimelinePlay
            // 
            this.numericTimelinePlay.Location = new System.Drawing.Point(94, 29);
            this.numericTimelinePlay.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numericTimelinePlay.Name = "numericTimelinePlay";
            this.numericTimelinePlay.Size = new System.Drawing.Size(51, 20);
            this.numericTimelinePlay.TabIndex = 6;
            // 
            // labelTimelineStart
            // 
            this.labelTimelineStart.AutoSize = true;
            this.labelTimelineStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimelineStart.Location = new System.Drawing.Point(3, 0);
            this.labelTimelineStart.Name = "labelTimelineStart";
            this.labelTimelineStart.Size = new System.Drawing.Size(85, 26);
            this.labelTimelineStart.TabIndex = 2;
            this.labelTimelineStart.Text = "Start time";
            this.labelTimelineStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimelinePlay
            // 
            this.labelTimelinePlay.AutoSize = true;
            this.labelTimelinePlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimelinePlay.Location = new System.Drawing.Point(3, 26);
            this.labelTimelinePlay.Name = "labelTimelinePlay";
            this.labelTimelinePlay.Size = new System.Drawing.Size(85, 26);
            this.labelTimelinePlay.TabIndex = 3;
            this.labelTimelinePlay.Text = "Play minutes";
            this.labelTimelinePlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimelinePause
            // 
            this.labelTimelinePause.AutoSize = true;
            this.labelTimelinePause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimelinePause.Location = new System.Drawing.Point(3, 52);
            this.labelTimelinePause.Name = "labelTimelinePause";
            this.labelTimelinePause.Size = new System.Drawing.Size(85, 26);
            this.labelTimelinePause.TabIndex = 5;
            this.labelTimelinePause.Text = "Pause minutes";
            this.labelTimelinePause.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimelinePeriods
            // 
            this.labelTimelinePeriods.AutoSize = true;
            this.labelTimelinePeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimelinePeriods.Location = new System.Drawing.Point(3, 78);
            this.labelTimelinePeriods.Name = "labelTimelinePeriods";
            this.labelTimelinePeriods.Size = new System.Drawing.Size(85, 29);
            this.labelTimelinePeriods.TabIndex = 4;
            this.labelTimelinePeriods.Text = "Periods";
            this.labelTimelinePeriods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupPhases
            // 
            this.groupPhases.Location = new System.Drawing.Point(208, 12);
            this.groupPhases.Name = "groupPhases";
            this.groupPhases.Size = new System.Drawing.Size(18, 24);
            this.groupPhases.TabIndex = 9;
            this.groupPhases.TabStop = false;
            this.groupPhases.Text = "Phases";
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.tableSettings);
            this.groupSettings.Location = new System.Drawing.Point(12, 145);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(184, 66);
            this.groupSettings.TabIndex = 4;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Settings";
            // 
            // tableSettings
            // 
            this.tableSettings.BackColor = System.Drawing.Color.Transparent;
            this.tableSettings.ColumnCount = 1;
            this.tableSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableSettings.Controls.Add(this.checkShowAfterMidnight, 0, 1);
            this.tableSettings.Controls.Add(this.checkResetAfterMidnight, 0, 0);
            this.tableSettings.Location = new System.Drawing.Point(0, 18);
            this.tableSettings.Name = "tableSettings";
            this.tableSettings.RowCount = 2;
            this.tableSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableSettings.Size = new System.Drawing.Size(182, 46);
            this.tableSettings.TabIndex = 2;
            // 
            // checkShowAfterMidnight
            // 
            this.checkShowAfterMidnight.AutoSize = true;
            this.checkShowAfterMidnight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkShowAfterMidnight.Location = new System.Drawing.Point(10, 26);
            this.checkShowAfterMidnight.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkShowAfterMidnight.Name = "checkShowAfterMidnight";
            this.checkShowAfterMidnight.Size = new System.Drawing.Size(169, 17);
            this.checkShowAfterMidnight.TabIndex = 3;
            this.checkShowAfterMidnight.Text = "Show after midnight";
            this.checkShowAfterMidnight.UseVisualStyleBackColor = true;
            // 
            // buttonResetConfig
            // 
            this.buttonResetConfig.Location = new System.Drawing.Point(3, 63);
            this.buttonResetConfig.Name = "buttonResetConfig";
            this.buttonResetConfig.Size = new System.Drawing.Size(175, 24);
            this.buttonResetConfig.TabIndex = 7;
            this.buttonResetConfig.Text = "Reset";
            this.buttonResetConfig.UseVisualStyleBackColor = true;
            // 
            // tableButtons
            // 
            this.tableButtons.ColumnCount = 1;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableButtons.Controls.Add(this.buttonApplyTemplorarily, 0, 0);
            this.tableButtons.Controls.Add(this.buttonResetConfig, 0, 2);
            this.tableButtons.Controls.Add(this.buttonSavePermanently, 0, 1);
            this.tableButtons.Location = new System.Drawing.Point(13, 451);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 3;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableButtons.Size = new System.Drawing.Size(182, 90);
            this.tableButtons.TabIndex = 8;
            // 
            // buttonApplyTemplorarily
            // 
            this.buttonApplyTemplorarily.Location = new System.Drawing.Point(3, 3);
            this.buttonApplyTemplorarily.Name = "buttonApplyTemplorarily";
            this.buttonApplyTemplorarily.Size = new System.Drawing.Size(175, 24);
            this.buttonApplyTemplorarily.TabIndex = 10;
            this.buttonApplyTemplorarily.Text = "Apply && close";
            this.buttonApplyTemplorarily.UseVisualStyleBackColor = true;
            // 
            // buttonSavePermanently
            // 
            this.buttonSavePermanently.Location = new System.Drawing.Point(3, 33);
            this.buttonSavePermanently.Name = "buttonSavePermanently";
            this.buttonSavePermanently.Size = new System.Drawing.Size(175, 24);
            this.buttonSavePermanently.TabIndex = 9;
            this.buttonSavePermanently.Text = "Save && close";
            this.buttonSavePermanently.UseVisualStyleBackColor = true;
            // 
            // panelAppearancePosition
            // 
            this.panelAppearancePosition.BackColor = System.Drawing.Color.Transparent;
            this.panelAppearancePosition.Controls.Add(this.labelAppearancePosition);
            this.panelAppearancePosition.Controls.Add(this.radioPositionRight);
            this.panelAppearancePosition.Controls.Add(this.radioPositionLeft);
            this.panelAppearancePosition.Controls.Add(this.radioPositionBottom);
            this.panelAppearancePosition.Controls.Add(this.radioPositionTop);
            this.panelAppearancePosition.Location = new System.Drawing.Point(1, 96);
            this.panelAppearancePosition.Name = "panelAppearancePosition";
            this.panelAppearancePosition.Size = new System.Drawing.Size(182, 98);
            this.panelAppearancePosition.TabIndex = 1;
            // 
            // labelAppearancePosition
            // 
            this.labelAppearancePosition.AutoSize = true;
            this.labelAppearancePosition.Location = new System.Drawing.Point(70, 40);
            this.labelAppearancePosition.Name = "labelAppearancePosition";
            this.labelAppearancePosition.Size = new System.Drawing.Size(44, 13);
            this.labelAppearancePosition.TabIndex = 4;
            this.labelAppearancePosition.Text = "Position";
            // 
            // radioPositionRight
            // 
            this.radioPositionRight.AutoSize = true;
            this.radioPositionRight.Location = new System.Drawing.Point(118, 40);
            this.radioPositionRight.Name = "radioPositionRight";
            this.radioPositionRight.Size = new System.Drawing.Size(14, 13);
            this.radioPositionRight.TabIndex = 3;
            this.radioPositionRight.TabStop = true;
            this.radioPositionRight.Tag = "Right";
            this.radioPositionRight.UseVisualStyleBackColor = true;
            // 
            // radioPositionLeft
            // 
            this.radioPositionLeft.AutoSize = true;
            this.radioPositionLeft.Location = new System.Drawing.Point(48, 40);
            this.radioPositionLeft.Name = "radioPositionLeft";
            this.radioPositionLeft.Size = new System.Drawing.Size(14, 13);
            this.radioPositionLeft.TabIndex = 2;
            this.radioPositionLeft.TabStop = true;
            this.radioPositionLeft.Tag = "Left";
            this.radioPositionLeft.UseVisualStyleBackColor = true;
            // 
            // radioPositionBottom
            // 
            this.radioPositionBottom.AutoSize = true;
            this.radioPositionBottom.Location = new System.Drawing.Point(85, 75);
            this.radioPositionBottom.Name = "radioPositionBottom";
            this.radioPositionBottom.Size = new System.Drawing.Size(14, 13);
            this.radioPositionBottom.TabIndex = 1;
            this.radioPositionBottom.TabStop = true;
            this.radioPositionBottom.Tag = "Bottom";
            this.radioPositionBottom.UseVisualStyleBackColor = true;
            // 
            // radioPositionTop
            // 
            this.radioPositionTop.AutoSize = true;
            this.radioPositionTop.Location = new System.Drawing.Point(85, 5);
            this.radioPositionTop.Name = "radioPositionTop";
            this.radioPositionTop.Size = new System.Drawing.Size(14, 13);
            this.radioPositionTop.TabIndex = 0;
            this.radioPositionTop.TabStop = true;
            this.radioPositionTop.Tag = "Top";
            this.radioPositionTop.UseVisualStyleBackColor = true;
            // 
            // panelScreens
            // 
            this.panelScreens.BackColor = System.Drawing.Color.Transparent;
            this.panelScreens.Controls.Add(this.listScreens);
            this.panelScreens.Location = new System.Drawing.Point(1, 54);
            this.panelScreens.Name = "panelScreens";
            this.panelScreens.Size = new System.Drawing.Size(182, 23);
            this.panelScreens.TabIndex = 7;
            // 
            // listScreens
            // 
            this.listScreens.FormattingEnabled = true;
            this.listScreens.IntegralHeight = false;
            this.listScreens.Location = new System.Drawing.Point(6, 3);
            this.listScreens.Name = "listScreens";
            this.listScreens.Size = new System.Drawing.Size(171, 17);
            this.listScreens.TabIndex = 0;
            // 
            // tableAppearanceBarWidth
            // 
            this.tableAppearanceBarWidth.BackColor = System.Drawing.Color.Transparent;
            this.tableAppearanceBarWidth.ColumnCount = 2;
            this.tableAppearanceBarWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAppearanceBarWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableAppearanceBarWidth.Controls.Add(this.numericAppearanceBarWidth, 1, 0);
            this.tableAppearanceBarWidth.Controls.Add(this.labelAppearanceBarWidth, 0, 0);
            this.tableAppearanceBarWidth.Location = new System.Drawing.Point(1, 19);
            this.tableAppearanceBarWidth.Name = "tableAppearanceBarWidth";
            this.tableAppearanceBarWidth.RowCount = 1;
            this.tableAppearanceBarWidth.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableAppearanceBarWidth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableAppearanceBarWidth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableAppearanceBarWidth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableAppearanceBarWidth.Size = new System.Drawing.Size(182, 30);
            this.tableAppearanceBarWidth.TabIndex = 7;
            // 
            // numericAppearanceBarWidth
            // 
            this.numericAppearanceBarWidth.Location = new System.Drawing.Point(94, 3);
            this.numericAppearanceBarWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericAppearanceBarWidth.Name = "numericAppearanceBarWidth";
            this.numericAppearanceBarWidth.Size = new System.Drawing.Size(51, 20);
            this.numericAppearanceBarWidth.TabIndex = 6;
            // 
            // labelAppearanceBarWidth
            // 
            this.labelAppearanceBarWidth.AutoSize = true;
            this.labelAppearanceBarWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAppearanceBarWidth.Location = new System.Drawing.Point(3, 0);
            this.labelAppearanceBarWidth.Name = "labelAppearanceBarWidth";
            this.labelAppearanceBarWidth.Size = new System.Drawing.Size(85, 30);
            this.labelAppearanceBarWidth.TabIndex = 3;
            this.labelAppearanceBarWidth.Text = "Bar width";
            this.labelAppearanceBarWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkAppearanceIgnoreTaskbar
            // 
            this.checkAppearanceIgnoreTaskbar.AutoSize = true;
            this.checkAppearanceIgnoreTaskbar.Location = new System.Drawing.Point(6, 200);
            this.checkAppearanceIgnoreTaskbar.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkAppearanceIgnoreTaskbar.Name = "checkAppearanceIgnoreTaskbar";
            this.checkAppearanceIgnoreTaskbar.Size = new System.Drawing.Size(94, 17);
            this.checkAppearanceIgnoreTaskbar.TabIndex = 8;
            this.checkAppearanceIgnoreTaskbar.Text = "Ignore taskbar";
            this.checkAppearanceIgnoreTaskbar.UseVisualStyleBackColor = true;
            // 
            // groupAppearance
            // 
            this.groupAppearance.Controls.Add(this.checkAppearanceIgnoreTaskbar);
            this.groupAppearance.Controls.Add(this.tableAppearanceBarWidth);
            this.groupAppearance.Controls.Add(this.panelScreens);
            this.groupAppearance.Controls.Add(this.panelAppearancePosition);
            this.groupAppearance.Location = new System.Drawing.Point(12, 217);
            this.groupAppearance.Name = "groupAppearance";
            this.groupAppearance.Size = new System.Drawing.Size(184, 228);
            this.groupAppearance.TabIndex = 6;
            this.groupAppearance.TabStop = false;
            this.groupAppearance.Text = "Appearance";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(236, 557);
            this.ControlBox = false;
            this.Controls.Add(this.tableButtons);
            this.Controls.Add(this.groupAppearance);
            this.Controls.Add(this.groupSettings);
            this.Controls.Add(this.groupTimeline);
            this.Controls.Add(this.groupPhases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::Timeliner.Resources.Icon;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.groupTimeline.ResumeLayout(false);
            this.tableTimeline.ResumeLayout(false);
            this.tableTimeline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTimelinePlay)).EndInit();
            this.groupSettings.ResumeLayout(false);
            this.tableSettings.ResumeLayout(false);
            this.tableSettings.PerformLayout();
            this.tableButtons.ResumeLayout(false);
            this.panelAppearancePosition.ResumeLayout(false);
            this.panelAppearancePosition.PerformLayout();
            this.panelScreens.ResumeLayout(false);
            this.tableAppearanceBarWidth.ResumeLayout(false);
            this.tableAppearanceBarWidth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAppearanceBarWidth)).EndInit();
            this.groupAppearance.ResumeLayout(false);
            this.groupAppearance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtTimelineStart;
        private System.Windows.Forms.CheckBox checkResetAfterMidnight;
        private System.Windows.Forms.GroupBox groupTimeline;
        private System.Windows.Forms.GroupBox groupPhases;
        private System.Windows.Forms.TableLayoutPanel tableTimeline;
        private System.Windows.Forms.Label labelTimelineStart;
        private System.Windows.Forms.Label labelTimelinePlay;
        private System.Windows.Forms.Label labelTimelinePause;
        private System.Windows.Forms.Label labelTimelinePeriods;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.TableLayoutPanel tableSettings;
        private System.Windows.Forms.CheckBox checkShowAfterMidnight;
        private System.Windows.Forms.NumericUpDown numericTimelinePlay;
        private System.Windows.Forms.NumericUpDown numericTimelinePeriods;
        private System.Windows.Forms.NumericUpDown numericTimelinePause;
        private Button buttonResetConfig;
        private TableLayoutPanel tableButtons;
        private Button buttonSavePermanently;
        private Button buttonApplyTemplorarily;
        private Panel panelAppearancePosition;
        private Label labelAppearancePosition;
        private RadioButton radioPositionRight;
        private RadioButton radioPositionLeft;
        private RadioButton radioPositionBottom;
        private RadioButton radioPositionTop;
        private Panel panelScreens;
        private ListBox listScreens;
        private TableLayoutPanel tableAppearanceBarWidth;
        private NumericUpDown numericAppearanceBarWidth;
        private Label labelAppearanceBarWidth;
        private CheckBox checkAppearanceIgnoreTaskbar;
        private GroupBox groupAppearance;
    }
}