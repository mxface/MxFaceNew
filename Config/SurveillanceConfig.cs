using Neurotec.Samples.Properties;
using Neurotec.Surveillance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Neurotec.Samples.Config
{
	public class SurveillanceConfig
	{
		#region Private static fields

		private static readonly JsonSerializerSettings FormatSetttings = new JsonSerializerSettings
		{
			Formatting = Formatting.Indented
		};

		#endregion

		#region Public constants

		public const string DBFileFaceWatchlist = "SurveillanceSampleWatchlistV10.db";
		public const string DBFileLicensePlateWatchlist = "LicensePlateWatchlistV10.db";
		public const string DBFileEvents = "SurveillanceSampleEventsV10.db";

		#endregion

		#region Public static properties

		public static bool SaveEvents
		{
			get
			{
				try { return Settings.Default.SaveEvents; }
				catch { return true; }
			}
			set
			{
				Settings.Default.SaveEvents = value;
			}
		}

		public static int MiscMaxTreeNodeCount
		{
			get
			{
				try { return Settings.Default.MiscMaxTreeNodeCount; }
				catch { return 100; }
			}
			set
			{
				Settings.Default.MiscMaxTreeNodeCount = value;
			}
		}

		public static int RetryFrequency
		{
			get
			{
				try { return Settings.Default.RetryFrequency; }
				catch { return 60; }
			}
			set
			{
				Settings.Default.RetryFrequency = value;
			}
		}

		public static string SurveillanceProperties
		{
			get
			{
				try { return Settings.Default.SurveillanceProperties; }
				catch { return string.Empty; }
			}
			set
			{
				Settings.Default.SurveillanceProperties = value;
			}
		}

		public static Orientation Orientation
		{
			get
			{
				try { return (Orientation)Settings.Default.Orientation; }
				catch { return Orientation.Vertical; }
			}
			set
			{
				Settings.Default.Orientation = (int)value;
			}
		}

		public static string Layout
		{
			get
			{
				try { return Settings.Default.Layout; }
				catch { return null; }
			}
			set
			{
				Settings.Default.Layout = value;
			}
		}

		public static bool ShowDetails
		{
			get
			{
				try { return Settings.Default.ShowDetails; }
				catch { return true; }
			}
			set
			{
				Settings.Default.ShowDetails = value;
			}
		}

		public static bool FirstStart
		{
			get
			{
				try { return Settings.Default.FirstStart; }
				catch { return true; }
			}
			set
			{
				Settings.Default.FirstStart = value;
			}
		}

		public static Dictionary<string, Preset> Presets
		{
			get
			{
				try
				{
					return JsonConvert.DeserializeObject<Dictionary<string, Preset>>(Settings.Default.PresetSettings)
						?? new Dictionary<string, Preset>();
				}
				catch { return new Dictionary<string, Preset>(); }
			}
			set
			{
				Settings.Default.PresetSettings = JsonConvert.SerializeObject(value, FormatSetttings);
				Settings.Default.Save();
			}
		}

		public static Dictionary<string, SourceConfiguration> SourceConfig
		{
			get
			{
				try
				{
					return JsonConvert.DeserializeObject<SourceConfiguration[]>(Settings.Default.SourceConfig, new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.All,
					})
					.ToDictionary(x => x.SourceId);
				}
				catch { return new Dictionary<string, SourceConfiguration>(); }
			}
			set
			{
				Settings.Default.SourceConfig = JsonConvert.SerializeObject(value?.Values.ToArray() ?? new SourceConfiguration[0], new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.All,
					Formatting = Formatting.Indented
				});
				Settings.Default.Save();
			}
		}

		public static Dictionary<string, RecentSourceConfig> RecentSources
		{
			get
			{
				try
				{
					var value = Settings.Default.RecentSources;
					if (!string.IsNullOrEmpty(value))
					{
						return JsonConvert.DeserializeObject<RecentSourceConfig[]>(value)
							.ToDictionary(x => x.Id);
					}

				}
				catch { }

				return new Dictionary<string, RecentSourceConfig>();
			}
			set
			{
				Settings.Default.RecentSources = JsonConvert.SerializeObject(value?.Values.ToArray() ?? new RecentSourceConfig[0], FormatSetttings);
				Settings.Default.Save();
			}
		}

		public static DetailsFilter DetailsFilter
		{
			get
			{
				try
				{

					if (!string.IsNullOrEmpty(Settings.Default.DetailsFilter))
					{
						return JsonConvert.DeserializeObject<DetailsFilter>(Settings.Default.DetailsFilter);
					}
					return new DetailsFilter();
				}
				catch { return new DetailsFilter(); }
			}
			set
			{
				if (value == null) throw new NullReferenceException(nameof(value));
				Settings.Default.DetailsFilter = JsonConvert.SerializeObject(value, FormatSetttings);
				Settings.Default.Save();
			}
		}

		public static NSurveillanceModalityType PreferredModalities
		{
			get
			{
				try
				{
					return (NSurveillanceModalityType)Settings.Default.PreferredModalities;
				}
				catch { return NSurveillanceModalityType.Faces | NSurveillanceModalityType.VehiclesAndHumans | NSurveillanceModalityType.LicensePlateRecognition; }
			}
			set
			{
				Settings.Default.PreferredModalities = (int)value;
				Settings.Default.Save();
			}
		}

		public static SourceCheckState SubjectFormConfig
		{
			get
			{
				try
				{
					return JsonConvert.DeserializeObject<SourceCheckState>(Settings.Default.SubjectFormConfig)
						?? new SourceCheckState();
				}
				catch { return new SourceCheckState(); }
			}
			set
			{
				Settings.Default.SubjectFormConfig = value != null ? JsonConvert.SerializeObject(value, FormatSetttings) : null;
				Settings.Default.Save();
			}
		}

		#endregion

		#region Public static methods

		public static void Save()
		{
			Settings.Default.Save();
		}

		public static void Reload()
		{
			Settings.Default.Reload();
		}

		private static string GetDefaultValue(string property)
		{
			System.ComponentModel.AttributeCollection attributes = System.ComponentModel.TypeDescriptor.GetProperties(Settings.Default)[property].Attributes;
			System.Configuration.DefaultSettingValueAttribute attribute = (System.Configuration.DefaultSettingValueAttribute)attributes[typeof(System.Configuration.DefaultSettingValueAttribute)];
			return attribute.Value;
		}

		public static void ResetGeneralSettings()
		{
			Settings.Default.MiscMaxTreeNodeCount = System.Int32.Parse(GetDefaultValue("MiscMaxTreeNodeCount"));
			Settings.Default.RetryFrequency = System.Int32.Parse(GetDefaultValue("RetryFrequency"));
			Settings.Default.SaveEvents = System.Boolean.Parse(GetDefaultValue("SaveEvents"));
		}

		#endregion
	}
}
