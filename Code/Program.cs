using Neurotec.Licensing;
using Neurotec.Samples.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Code
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			string [] Components = new string[]
			{
				"SentiVeillanceVH",
				"SentiVeillanceALPR",
				"SentiVeillance"
			};

			//=========================================================================
			// TRIAL MODE
			//=========================================================================
			// Below code line determines whether TRIAL is enabled or not. To use purchased licenses, don't use below code line.
			// GetTrialModeFlag() method takes value from "Bin/Licenses/TrialFlag.txt" file. So to easily change mode for all our examples, modify that file.
			// Also you can just set TRUE to "TrialMode" property in code.

			NLicenseManager.TrialMode = Utils.GetTrialModeFlag();

			Console.WriteLine("Trial mode: " + NLicenseManager.TrialMode);

			//=========================================================================

			try
			{
				bool any = false;
				foreach (string component in Components)
				{
					any |= NLicense.Obtain("/local", 5000, component);
				}
				if (!any)
				{
					MessageBox.Show(string.Format("Could not obtain licenses for any of components: {0}", Components.Aggregate((a, b) => a + ", " + b)));
					return;
				}
			}
			catch (Exception ex)
			{
				string message = string.Format("Failed to obtain licenses for components.\nError message: {0}", ex.Message);
				if (ex is System.IO.IOException)
				{
					message += "\n(Probably licensing service is not running. Use Activation Wizard to figure it out.)";
				}
				MessageBox.Show(message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm(args));
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Unhandled exception. Details: {0}", ex), @"Surveillance Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
