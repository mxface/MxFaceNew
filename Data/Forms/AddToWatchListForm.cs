using Neurotec.Biometrics;
using Neurotec.Samples.Code;
using System.Windows.Forms;

namespace Neurotec.Samples.Data.Forms
{
	public partial class AddToWatchListForm : Form
	{
		#region Public constructor

		public AddToWatchListForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Public methods

		public DialogResult ShowDialog(SubjectInfo si)
		{
			var attributes = new NLAttributes
			{
				BoundingRect = si.Face.BestAttributes.BoundingRect,
				LeftEyeCenter = si.Face.BestAttributes.LeftEyeCenter,
				RightEyeCenter = si.Face.BestAttributes.RightEyeCenter
			};
			view.Face = NFace.FromImageAndAttributes(si.BestImage, attributes);

			return base.ShowDialog();
		}

		#endregion

		#region Public properties

		public string SubjectId
		{
			get { return textBoxSubjectId.Text; }
			set { textBoxSubjectId.Text = value; }
		}

		#endregion
	}
}
