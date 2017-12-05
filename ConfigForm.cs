#region References

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timeliner.Configuration;
using Timeliner.Controls;
using Timeliner.Helpers;
using Timeliner.Types;

#endregion

namespace Timeliner
{
	public partial class ConfigForm : Form
	{
		private TimelinerConfig config;
		private ExTableLayoutPanel tablePhases;
		private const int CONST_defaultRowWidth = 30;
		private const int CONST_defaultCellPadding = 3;
		private Button buttonPhaseAdd;

		private Dictionary<ToolTipIcon, Bitmap> phaseIcons = new Dictionary<ToolTipIcon, Bitmap>
		{
			{ToolTipIcon.None, Resources.None},
			{ToolTipIcon.Info, Resources.Info},
			{ToolTipIcon.Warning, Resources.Warning},
			{ToolTipIcon.Error, Resources.Error},
		};

		public TimelinerConfig Config
		{
			get { return this.config; }
		}

		public ConfigForm()
		{
		}

		public void BuildForm(TimelinerConfig _config)
		{
			this.config = _config;
			this.InitializeComponent();
			this.BuildForm();
			this.Show();
		}

		private void BuildForm()
		{
			this.BuildTimelineStart();
			this.BuildTimelinePlay();
			this.BuildTimelinePause();
			this.BuildTimelinePeriods();

			this.BuildSettingsResetAfterMidnight();
			this.BuildSettingsShowAfterMidnight();

			this.BuildAppearanceBarWidth();
			this.BuildAppearanceScreens();
			this.BuildAppearancePosition();
			this.BuildAppearanceIgnoreTaskbar();

			this.BuildButtons();

			this.BuildPhases();
		}

		private void BuildTimelineStart()
		{
			DateTime value = this.config.Timeline.Start.GetDate();
			this.txtTimelineStart.Width = TextRenderer.MeasureText(this.txtTimelineStart.Mask, this.txtTimelineStart.Font).Width;
			this.txtTimelineStart.Text = value.ToLongTimeString();
			this.txtTimelineStart.LostFocus += (s, e) => ((MaskedTextBox) s).ValidateText();
			this.txtTimelineStart.Validating += (s, e) => e.Cancel = !DateTime.TryParse(((MaskedTextBox) s).Text, out value);
			this.txtTimelineStart.Validated += (s, e) => this.config.Timeline.Start.SetDate(value);
		}

		private void BuildTimelinePlay()
		{
			this.numericTimelinePlay.Width = this.txtTimelineStart.Width;
			this.numericTimelinePlay.Value = this.config.Timeline.Play;
			this.numericTimelinePlay.Validated += (s, e) => this.config.Timeline.Play = (int) ((NumericUpDown) s).Value;
		}

		private void BuildTimelinePause()
		{
			this.numericTimelinePause.Width = this.txtTimelineStart.Width;
			this.numericTimelinePause.Value = this.config.Timeline.Pause;
			this.numericTimelinePause.ValueChanged += (s, e) => this.config.Timeline.Pause = (int) ((NumericUpDown) s).Value;
		}

		private void BuildTimelinePeriods()
		{
			this.numericTimelinePeriods.Width = this.txtTimelineStart.Width;
			this.numericTimelinePeriods.Value = this.config.Timeline.Periods;
			this.numericTimelinePeriods.ValueChanged += (s, e) => this.config.Timeline.Periods = (int) ((NumericUpDown) s).Value;
		}

		private void BuildSettingsResetAfterMidnight()
		{
			this.checkResetAfterMidnight.Checked = this.config.Settings.ResetAfterMidnight;
			this.checkResetAfterMidnight.CheckedChanged += (s, e) => this.config.Settings.ResetAfterMidnight = ((CheckBox) s).Checked;
		}

		private void BuildSettingsShowAfterMidnight()
		{
			this.checkShowAfterMidnight.Checked = this.config.Settings.ShowAfterMidnight;
			this.checkShowAfterMidnight.CheckedChanged += (s, e) => this.config.Settings.ShowAfterMidnight = ((CheckBox) s).Checked;
		}

		private void BuildPhases()
		{
			this.BuildPhasesWrapper();

			foreach (PhaseElement phase in this.config.Phases)
			{
				this.BuildPhase(phase);
			}
		}

		private void BuildPhasesWrapper()
		{
			this.tablePhases = new ExTableLayoutPanel
			{
				BackColor = Color.Transparent,
				CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetPartial,
				Location = new Point(9, 15),
				Size = new Size(CONST_defaultCellPadding, CONST_defaultCellPadding)
			};
			this.tablePhases.SuspendLayout();
			this.groupPhases.SuspendLayout();

			this.BuildStaticPhaseControls();

			this.groupPhases.Controls.Clear();
			this.groupPhases.Controls.Add(this.tablePhases);
			this.groupPhases.ResumeLayout();
			this.tablePhases.ResumeLayout();
		}

		private void BuildStaticPhaseControls()
		{
			new List<int> {60, 400, 30, 30, 30, 30, 220, 100}.ForEach(this.AddPhaseColumn);

			for (int i = 0; i < 2; i++)
			{
				this.AddPhaseRow();
			}

			int col = 2;
			foreach (KeyValuePair<ToolTipIcon, Bitmap> kvp in this.phaseIcons)
			{
				this.CreatePhaseControl<Panel>(0, col++, 7).BackgroundImage = kvp.Value;
			}

			List<KeyValuePair<string, int>> headerLabels = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("Color", 0),
				new KeyValuePair<string, int>("Position", 1),
				new KeyValuePair<string, int>("Message", 6)
			};
			foreach (KeyValuePair<string, int> kvp in headerLabels)
			{
				Label label = this.CreatePhaseControl<Label>(0, kvp.Value, 0);
				label.TextAlign = ContentAlignment.MiddleCenter;
				label.Text = kvp.Key;
			}

			this.buttonPhaseAdd = this.CreatePhaseControl<Button>(1, 7, 3);
			this.buttonPhaseAdd.Text = Resources.ConfigForm_Add;
			this.buttonPhaseAdd.Click += (s, e) =>
			{
				PhaseElement phase = new PhaseElement().Default();
				this.BuildPhase(phase);
				this.config.Phases.Add(phase);
			};
		}

		private void AddPhaseColumn(int width)
		{
			this.tablePhases.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, width));
			this.tablePhases.ColumnCount++;
			this.tablePhases.Width += CONST_defaultCellPadding + width;
			this.groupPhases.Width += CONST_defaultCellPadding + width;
		}

		private void AddPhaseRow()
		{
			this.tablePhases.RowStyles.Add(new RowStyle(SizeType.Absolute, CONST_defaultRowWidth));
			this.tablePhases.RowCount++;
			this.tablePhases.Height += CONST_defaultCellPadding + CONST_defaultRowWidth;
			this.groupPhases.Height += CONST_defaultCellPadding + CONST_defaultRowWidth;
		}

		private void RemovePhaseRow(int rowNumber)
		{
			this.tablePhases.RemoveRow(rowNumber);
			this.tablePhases.RowCount--;
			this.groupPhases.Height -= CONST_defaultCellPadding + CONST_defaultRowWidth;
			this.tablePhases.Height -= CONST_defaultCellPadding + CONST_defaultRowWidth;
		}

		private void BuildPhase(PhaseElement phase)
		{
			this.tablePhases.SuspendLayout();

			PhaseElement phase1 = phase;
			int? begin = phase1.GetNaturalBegin();

			this.AddPhaseRow();

			Panel panelPhase = this.CreatePhaseControl<Panel>(-2, 0, 7);
			panelPhase.BorderStyle = BorderStyle.FixedSingle;
			panelPhase.BackColor = phase1.GetColor();
			panelPhase.Click += (s, e) =>
			{
				ColorDialog colorDialog = new ColorDialog
				{
					Color = ((Panel) s).BackColor
				};
				colorDialog.ShowDialog();
				((Panel) s).BackColor = colorDialog.Color;
				phase1.SetColor(colorDialog.Color);
			};

			if (begin.HasValue)
			{
				TrackBar trackBarPhase = this.CreatePhaseControl<TrackBar>(-2, 1, 6);
				trackBarPhase.Height = 45;
				trackBarPhase.Margin = new Padding(trackBarPhase.Margin.All)
				{
					Bottom = 0
				};
				trackBarPhase.Enabled = phase1.Begin >= 0;
				trackBarPhase.Maximum = 100;
				trackBarPhase.TickFrequency = 5;
				trackBarPhase.TickStyle = TickStyle.None;
				trackBarPhase.Value = phase1.Begin;

				ToolTip toolTip = new ToolTip
				{
					InitialDelay = 0,
					AutoPopDelay = 0,
					ReshowDelay = 0,
					UseFading = false,
					UseAnimation = false
				};
				EventHandler toolTipShow = (s, e) => toolTip.SetToolTip(trackBarPhase, string.Format("{0}%", trackBarPhase.Value));
				trackBarPhase.GotFocus += toolTipShow;
				trackBarPhase.Scroll += toolTipShow;
				trackBarPhase.Scroll += (s, e) => { phase1.Begin = ((TrackBar) s).Value; };
			}

			Panel radioPanel = this.CreatePhaseControl<Panel>(-2, 2, 0);
			radioPanel.Size = new Size(127, 28);
			this.tablePhases.SetColumnSpan(radioPanel, 4);
			radioPanel.SuspendLayout();

			int position = 9;
			foreach (KeyValuePair<ToolTipIcon, Bitmap> kvp in this.phaseIcons)
			{
				RadioButton radioButton = new RadioButton
				{
					Anchor = AnchorStyles.Top,
					Location = new Point(position, 8),
					Size = new Size(12, 14),
					Checked = phase1.GetIcon() == kvp.Key,
					Tag = kvp.Key
				};
				radioButton.CheckedChanged += (s, e) =>
				{
					if (((RadioButton) s).Checked)
					{
						phase1.SetIcon((ToolTipIcon) ((RadioButton) s).Tag);
					}
				};
				radioPanel.Controls.Add(radioButton);
				position += 33;
			}
			radioPanel.ResumeLayout(false);
			
			TextBox textMessagePhase = this.CreatePhaseControl<TextBox>(-2, 6, 5);
			textMessagePhase.Dock = DockStyle.Top;
			textMessagePhase.Text = phase1.GetMessage();
			textMessagePhase.TextChanged += (s, e) => phase1.SetMessage(((TextBox) s).Text);

			this.AddPhaseControl(this.buttonPhaseAdd, -1, 7, 3);

			Button buttonPhaseDelete = this.CreatePhaseControl<Button>(-2, 7, 3);
			buttonPhaseDelete.Text = Resources.ConfigForm_Delete;
			buttonPhaseDelete.Visible = phase1.Begin >= 0;
			buttonPhaseDelete.Click += (s, e) =>
			{
				if (MessageBox.Show(Resources.ConfigForm_Are_you_sure,
				                    Resources.ConfigForm_Delete_phase,
				                    MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					this.tablePhases.SuspendLayout();
					this.config.Phases.Remove(phase1);
					this.RemovePhaseRow(this.tablePhases.GetRow(((Button) s)));
					this.AddPhaseControl(this.buttonPhaseAdd, -1, 7, 3);
					this.tablePhases.ResumeLayout();
				}
			};

			this.tablePhases.ResumeLayout();
		}

		private T CreatePhaseControl<T>(int rowPosition, int colPosition, int padding)
			where T : Control, new()
		{
			T control = new T();
			return this.AddPhaseControl(control, rowPosition, colPosition, padding);
		}

		private T AddPhaseControl<T>(T control, int rowPosition, int colPosition, int padding)
			where T : Control
		{
			if (rowPosition < 0)
			{
				rowPosition = this.tablePhases.RowCount + rowPosition;
			}

			control.Height = (int) this.tablePhases.RowStyles[rowPosition].Height - 2 * padding;
			control.Margin = new Padding(padding);

			control.Width = (int) this.tablePhases.ColumnStyles[colPosition].Width - 2 * padding;
			this.tablePhases.Controls.Add(control, colPosition, rowPosition);
			return control;
		}

		private void BuildAppearanceBarWidth()
		{
			this.numericAppearanceBarWidth.Value = this.config.Appearance.BarWidth;
			this.numericAppearanceBarWidth.ValueChanged += (s, e) => this.config.Appearance.BarWidth = (int) ((NumericUpDown) s).Value;
		}

		private void BuildAppearanceScreens()
		{
			for (int i = 0; i < Screen.AllScreens.Length; i++)
			{
				this.listScreens.Items.Add(string.Format("Screen {0}", i + 1));
			}

			int increaseHeight = this.listScreens.ItemHeight * (this.listScreens.Items.Count - 1);
			this.listScreens.Height += increaseHeight;
			this.panelScreens.Height += increaseHeight;
			this.listScreens.SelectedIndex = this.config.Appearance.ScreenIndex;
			this.listScreens.SelectedValueChanged += (s, e) => { this.config.Appearance.ScreenIndex = ((ListBox) s).SelectedIndex; };
		}

		private void BuildAppearancePosition()
		{
			Position position = this.config.Appearance.GetPosition();
			List<Control> radioButtons = this.panelAppearancePosition.Controls
				.Cast<Control>()
				.Where(control => control is RadioButton)
				.ToList();

			foreach (Position value in Enum.GetValues(typeof (Position)))
			{
				Position value1 = value;
				RadioButton radioButton = (RadioButton) radioButtons.Single(control => control.Tag.ToString() == value1.ToString());
				radioButton.Checked = position == value;
				radioButton.CheckedChanged += (s, e) =>
				{
					if (((RadioButton) s).Checked)
					{
						this.config.Appearance.Position = value1.ToString();
					}
				};
			}
		}

		private void BuildAppearanceIgnoreTaskbar()
		{
			this.checkAppearanceIgnoreTaskbar.Checked = this.config.Appearance.IgnoreTaskbar;
			this.checkAppearanceIgnoreTaskbar.CheckedChanged += (s, e) => this.config.Appearance.IgnoreTaskbar = ((CheckBox) s).Checked;
		}

		private void BuildButtons()
		{
			this.buttonApplyTemplorarily.Click += (s, e) => this.Close();
			new ToolTip().SetToolTip(this.buttonApplyTemplorarily, "Just close this form");
			this.buttonSavePermanently.Click += (s, e) => this.SaveAndClose();
			new ToolTip().SetToolTip(this.buttonSavePermanently, "Save settings forever and close this form");
			this.buttonResetConfig.Click += (s, e) => Application.OpenForms.OfType<Form1>().Single().Reset();
			new ToolTip().SetToolTip(this.buttonResetConfig, "Reset settings and reopen this form");
		}

		private void SaveAndClose()
		{
			ConfigHelper.WriteConfig(this.config);
			this.Close();
		}
	}
}