using Neurotec.Surveillance;
using System.Drawing;

namespace Neurotec.Samples.Drawing
{
	public static class TriggerDrawingExtensions
	{
		#region Public static methods

		public static Color GetColor(this NAnalyticTrigger ev)
		{
			var color = ev.GetProperty<Color>("Color");
			if (color == null)
			{
				color = Color.OrangeRed;
			}
			return color;
		}

		public static string GetName(this NAnalyticTrigger ev) => ev.GetProperty<string>("Name");

		#endregion
	}

}
