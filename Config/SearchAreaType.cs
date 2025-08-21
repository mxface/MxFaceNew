using Neurotec.Surveillance;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Neurotec.Samples.Config
{
	public class SearchAreaType
	{
		#region Public properties

		public NSearchAreaType Type { get; set; }
		public RectangleF Rect { get; set; }
		public List<PointF> Points { get; set; }

		#endregion

		#region Public operators

		public static implicit operator NSearchArea(SearchAreaType value)
		{
			if (value != null)
			{
				if (value.Points?.Any() == true)
				{
					var area = new NPolygonSearchArea() { Type = value.Type };
					foreach (var p in value.Points)
					{
						area.Points.Add(p);
					}
					return area;
				}
				else
				{
					return new NRectangleSearchArea()
					{
						Type = value.Type,
						Rectangle = value.Rect
					};
				}
			}
			return null;
		}

		public static implicit operator SearchAreaType(NSearchArea value)
		{
			if (value != null)
			{
				return new SearchAreaType
				{
					Type = value.Type,
					Points = value is NPolygonSearchArea parea ? parea.Points.ToList() : null,
					Rect = value is NRectangleSearchArea rarea ? rarea.Rectangle : RectangleF.Empty,
				};
			}
			return null;
		}

		#endregion
	}
}
