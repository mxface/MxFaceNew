using System.Drawing;

namespace Neurotec.Samples.Config.Forms.Tools
{
	public interface ICompleableTool
	{
		bool CompleteModification(int w, int h, bool addPoint);
		PointF StartPosition { get; set; }
		bool Modifying { get; set; }
	}
}
