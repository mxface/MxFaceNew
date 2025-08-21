using Neurotec.Samples.Code;
using Neurotec.Samples.Config;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Neurotec.Samples.Forms
{
	public partial class SourceHeader : UserControl
	{
		#region Private fields

		private SourceController _state;
		private SourceCheckState _checkState;
		private bool _showExpandedButtons = false;

		#endregion

		#region Public constructor

		public SourceHeader()
		{
			InitializeComponent();
			ApplyColors();
			chbSearchArea.Text = string.Empty;
			chbTriggers.Text = string.Empty;
		}

		#endregion

		#region Public properties

		public string Title
		{
			get => lblTitle.Text;
			set => lblTitle.Text = value;
		}

		public SourceController State
		{
			get => _state;
			set
			{
				if (_state != value)
				{
					if (_state != null) _state.PropertyChanged -= SourceStatePropertyChanged;
					_state = value;
					ApplyColors();
					if (_state != null)
					{
						_state.PropertyChanged += SourceStatePropertyChanged;
						ApplyState(value);
						CheckState = null;
					}
				}
			}
		}

		public SourceCheckState CheckState
		{
			get => _checkState;
			set
			{
				if (_checkState != null) _checkState.PropertyChanged -= CheckStatePropertyChanged;
				_checkState = value;
				if (_checkState != null)
				{
					_checkState.PropertyChanged += CheckStatePropertyChanged;
					ApplyState(value);
					State = null;
				}
			}
		}

		public Color ActiveColor { get; set; } = SystemColors.ActiveCaption;
		public Color ActiveSecondaryColor { get; set; } = SystemColors.InactiveCaption;
		public Color PassiveColor { get; set; } = Color.DarkGray;
		public Color PassiveSecondaryColor { get; set; } = Color.LightGray;

		public bool ShowPinButton
		{
			get => chbPin.Visible;
			set => chbPin.Visible = value;
		}
		public bool ShowTitle
		{
			get => lblTitle.Visible;
			set
			{
				lblTitle.Visible = value;
				ApplyColors();
			}
		}
		public bool ShowExpandedButtons
		{
			get => _showExpandedButtons;
			set
			{
				_showExpandedButtons = value;
				if (value)
				{
					chbSearchArea.Text = "Show Search Area";
					chbTriggers.Text = "Show Triggers";
				}
				else
				{
					chbSearchArea.Text = string.Empty;
					chbTriggers.Text = string.Empty;
				}
			}
		}
		public bool ShowTrackLineButton
		{
			get => chbShowTrackLine.Visible;
			set
			{
				chbShowTrackLine.Visible = value;
				UpdateShortcuts();
			}
		}

		#endregion

		#region Public events

		public event EventHandler HeaderMouseLeft;

		#endregion

		#region Protected methods

		protected override void Dispose(bool disposing)
		{
			State = null;
			CheckState = null;

			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#endregion

		#region Private methods

		private void UpdateShortcuts()
		{
			if (ShowTrackLineButton)
			{
				var value = toolTip1.GetToolTip(chbSearchArea);
				toolTip1.SetToolTip(chbSearchArea, value.Replace('1', '2'));

				value = toolTip1.GetToolTip(chbTriggers);
				toolTip1.SetToolTip(chbTriggers, value.Replace('2', '3'));

				value = toolTip1.GetToolTip(chbPin);
				toolTip1.SetToolTip(chbPin, value.Replace('3', '4'));
			}
			else
			{
				var value = toolTip1.GetToolTip(chbSearchArea);
				toolTip1.SetToolTip(chbSearchArea, value.Replace('2', '1'));

				value = toolTip1.GetToolTip(chbTriggers);
				toolTip1.SetToolTip(chbTriggers, value.Replace('3', '2'));

				value = toolTip1.GetToolTip(chbPin);
				toolTip1.SetToolTip(chbPin, value.Replace('4', '3'));
			}
		}

		private void ApplyState(SourceCheckState state)
		{
			chbPin.Checked = state.ShowHeader;
			chbSearchArea.Checked = state.ShowSearchArea;
			chbTriggers.Checked = state.ShowTriggers;
			chbShowTrackLine.Checked = state.ShowTrackLine;
		}

		private void CheckStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			ApplyState(CheckState);
		}

		private void SourceStatePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsSelected")
			{
				ApplyColors();
			}
			else
			{
				ApplyState(State);
			}
		}

		private void ApplyColors()
		{
			bool isActive = State?.IsSelected == true;

			if (ShowTitle)
				BackColor = isActive ? ActiveColor : PassiveColor;
			else
				BackColor = Color.Transparent;
			chbPin.FlatAppearance.CheckedBackColor = isActive ? ActiveColor : PassiveColor;
			chbPin.BackColor = isActive ? ActiveSecondaryColor : PassiveSecondaryColor;
			chbSearchArea.FlatAppearance.CheckedBackColor = isActive ? ActiveColor : PassiveColor;
			chbSearchArea.BackColor = isActive ? ActiveSecondaryColor : PassiveSecondaryColor;
			chbTriggers.FlatAppearance.CheckedBackColor = isActive ? ActiveColor : PassiveColor;
			chbTriggers.BackColor = isActive ? ActiveSecondaryColor : PassiveSecondaryColor;
			chbShowTrackLine.FlatAppearance.CheckedBackColor = isActive ? ActiveColor : PassiveColor;
			chbShowTrackLine.BackColor = isActive ? ActiveSecondaryColor : PassiveSecondaryColor;
		}

		private void LblTitleMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Clicks == 1)
			{
				if (e.Button == MouseButtons.Left && State != null)
				{
					DoDragDrop(State, DragDropEffects.Move | DragDropEffects.Link);
					State.SelectSource();
				}
			}
		}

		private void ChbSearchAreaCheckedChanged(object sender, System.EventArgs e)
		{
			if (State != null)
				State.ShowSearchArea = chbSearchArea.Checked;
			if (CheckState != null)
				CheckState.ShowSearchArea = chbSearchArea.Checked;
		}

		private void ChbTriggersCheckedChanged(object sender, System.EventArgs e)
		{
			if (State != null)
				State.ShowTriggers = chbTriggers.Checked;
			if (CheckState != null)
				CheckState.ShowTriggers = chbTriggers.Checked;
		}

		private void ChbPinCheckedChanged(object sender, System.EventArgs e)
		{
			if (State != null)
				State.ShowSourceHeader = chbPin.Checked;
			if (CheckState != null)
				CheckState.ShowHeader = chbPin.Checked;
		}

		private void ChbShowTrackLineCheckedChanged(object sender, EventArgs e)
		{
			if (CheckState != null)
				CheckState.ShowTrackLine = chbShowTrackLine.Checked;
		}

		private void MouseLeftChild(object sender, EventArgs e)
		{
			if (!ClientRectangle.Contains(PointToClient(MousePosition)))
			{
				HeaderMouseLeft?.Invoke(this, EventArgs.Empty);
			}
		}

		#endregion
	}
}
