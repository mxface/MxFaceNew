using Neurotec.Biometrics;
using Neurotec.Images;
using Neurotec.IO;
using Neurotec.Samples.Code;
using Neurotec.Samples.Properties;
using Neurotec.Surveillance;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neurotec.Samples.Data.Forms
{
	public partial class EnrollForm : Form
	{
		#region Private types

		private static class LineColor
		{
			public static readonly Color Normal = Color.Black;
			public static readonly Color Blue = Color.Blue;
			public static readonly Color Error = Color.FromArgb(255, 196, 0, 0);
		};

		#endregion

		#region Public constructor

		public EnrollForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private fields

		private NBiometricEngine _biometricEngine;
		private bool _cancel = false;
		private bool _isBusy = false;
		private int _index = 0;

		#endregion

		#region Public properties

		public string DirectoryPath { get; set; }
		public string[] Files { get; set; }
		public NSurveillance Surveillance { get; set; }
		public FaceRecordCollection FaceRecordsCollection { get; set; }

		#endregion

		#region Private methods

		private static string[] GetAllImages(string path)
		{
			var results = new List<string>();
			string[] extensions = NImages.GetOpenFileFilter().Split(';').Select(x => x.Replace("*.", string.Empty)).ToArray();
			string[] allFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
			return allFiles.Where(x => extensions.Any(e => x.EndsWith(e, StringComparison.CurrentCultureIgnoreCase))).ToArray();
		}

		private void EnrollFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (_isBusy)
			{
				e.Cancel = true;
				btnAction.Text = @"Stopping ...";
				btnAction.Enabled = false;
			}
		}

		private async void EnrollFormLoadAsync(object sender, EventArgs e)
		{
			Settings settings = Settings.Default;
			_biometricEngine = new NBiometricEngine();

			if (!string.IsNullOrWhiteSpace(DirectoryPath))
			{
				Files = GetAllImages(DirectoryPath);
			}

			if (Files == null || Files.Length == 0)
			{
				WriteLog(LineColor.Error, "No files selected for template extraction");
				return;
			}

			WriteLog(LineColor.Normal, "Selected {0} file(s) for template extraction", Files.Length);

			_biometricEngine.FacesTemplateSize = Surveillance.FacesTemplateSize;
			_biometricEngine.FacesDetermineGender = true;
			_biometricEngine.FacesDetectProperties = true;
			_biometricEngine.FacesDetermineAge = true;
			_biometricEngine.FacesDetectProperties = true;

			_isBusy = true;
			while (!_cancel && _index < Files.Length)
			{
				await CreateNextTemplateAsync(Files[_index]);
				_index++;
			}

			OnFinished();
		}

		private void WriteLog(Color color, string text)
		{
			rtbLog.SelectionColor = color;
			rtbLog.AppendText(text + "\n");
			rtbLog.Focus();
			rtbLog.SelectionStart = rtbLog.TextLength;
		}

		private void WriteLog(Color color, string format, params object[] args)
		{
			WriteLog(color, string.Format(format, args));
		}

		private void WriteLog(string text)
		{
			WriteLog(LineColor.Normal, text);
		}

		private void AddSubject(string subjectId, NBuffer features, NLAttributes bestAttributes, NImage bestImage, NImage thumbnail)
		{
			Surveillance.AddTemplate(subjectId, features);
			var faceRecord = new FaceRecord(-1, features.ToArray(), subjectId, DateTime.Now, bestAttributes);
			FaceRecordsCollection.Add(faceRecord, bestImage, thumbnail);
		}

		private async Task CreateNextTemplateAsync(string fileName)
		{
			var subject = new NSubject { Id = Path.GetFileNameWithoutExtension(fileName) };
			var face = new NFace { FileName = fileName };
			subject.Faces.Add(face);

			WriteLog(LineColor.Blue, "[{0}/{1}] {2}", _index + 1, Files.Length, fileName);

			try
			{
				var status = await _biometricEngine.CreateTemplateAsync(subject);
				if (status == NBiometricStatus.Ok)
				{
					WriteLog("template created successfully");
					using (var template = subject.GetTemplate())
					{
						using (var thumb = await Task.Run(() => SubjectInfo.CutAndScaleFaceThumbnail(face.Image, face.Objects[0])))
						using (var templateBuffer = template.Save())
						{
							AddSubject(subject.Id, templateBuffer, face.Objects.First(), face.Image, thumb);
						}
						WriteLog("template added to database successfully");
					}
				}
				else WriteLog(LineColor.Error, "failed to create template: {0}", status);
			}
			catch (Exception ex)
			{
				WriteLog(LineColor.Error, "Exception occurred: {0}", ex);
			}
		}

		private void OnFinished()
		{
			if (_cancel) WriteLog(LineColor.Error, "canceled");
			else WriteLog(LineColor.Blue, "done");

			_isBusy = false;
			btnAction.Text = "Close";
			btnAction.Enabled = true;

			if (_cancel)
				DialogResult = DialogResult.OK;

		}

		private void BtnActionClick(object sender, EventArgs e)
		{
			if (_cancel) return;

			_cancel = true;
			if (_isBusy)
			{
				btnAction.Text = @"Stopping...";
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}

		#endregion
	}
}
