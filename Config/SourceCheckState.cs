using Neurotec.Samples.Code;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Neurotec.Samples.Config
{
	public class SourceCheckState : INotifyPropertyChanged
	{
		private bool _showSearchArea = true;
		private bool _showTriggers = true;
		private bool _showHeader = true;
		private bool _showTrackLine = true;

		public bool ShowSearchArea
		{
			get => _showSearchArea;
			set => SetProperty(ref _showSearchArea, value);
		}

		public bool ShowTriggers
		{
			get => _showTriggers;
			set => SetProperty(ref _showTriggers, value);
		}

		public bool ShowHeader
		{
			get => _showHeader;
			set => SetProperty(ref _showHeader, value);
		}

		public bool ShowTrackLine
		{
			get => _showTrackLine;
			set => SetProperty(ref _showTrackLine, value);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private bool SetProperty<T>(ref T value, T newValue, [CallerMemberName] string propertyName = null)
		{
			if (!object.Equals(value, newValue))
			{
				value = newValue;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
				return true;
			}

			return false;
		}

		public static implicit operator SourceCheckState(SourceController value)
		{
			return new SourceCheckState
			{
				ShowSearchArea = value?.ShowSearchArea ?? true,
				ShowTriggers = value?.ShowTriggers ?? true,
				ShowHeader = value?.ShowSourceHeader ?? true,
			};
		}
	}

}
