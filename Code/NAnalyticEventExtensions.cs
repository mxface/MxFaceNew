using Neurotec.Surveillance;
using System;
using System.Drawing;

namespace Neurotec.Samples.Code
{
	public static class NAnalyticEventExtensions
	{
		public static string GetEventDescriptionWithTime(this NAnalyticEvent ev, bool isFromVideo)
		{
			var time = isFromVideo ?
					ev.VideoTimeStamp.ToString("hh\\:mm\\:ss") :
					ev.TimeStamp.ToLocalTime().ToString("HH\\:mm\\:ss");

			return $"{ev.GetEventDescription(false)}\r\n    {time}";
		}

		public static string GetEventDescription(this NAnalyticEvent ev, bool lean = true)
		{
			string name = ev.GetTriggerName();
			var type = ev.EventType;

			name = string.IsNullOrWhiteSpace(name) ? "NO_NAME" : $"'{name}'";
			if (type == NAnalyticEventType.CrossedIn || type == NAnalyticEventType.CrossedOut)
			{
				var direction = ev.EventType == NAnalyticEventType.CrossedIn ? "IN" : "OUT";
				return $"{name} crossed {direction}";
			}
			else if (type == NAnalyticEventType.AppearedIn || type == NAnalyticEventType.DisappearedIn)
			{
				var action = type == NAnalyticEventType.AppearedIn ? "Appeared IN" : "Disappeared IN";
				return $"{name} {action} region";
			}
			else if (type == NAnalyticEventType.Timer)
			{
				return lean ? $"{name} {type}" : $"{name} {type} \nDuration: {ev.TimerDuration}";
			}
			else if (type == NAnalyticEventType.TimerStart || type == NAnalyticEventType.TimerStop)
			{
				return $"{name} {type}";
			}
			throw new NotSupportedException();
		}

		public static Color GetTriggerColor(this NAnalyticEvent ev)
		{
			using (var trigger = ev.Trigger)
			{
				return trigger.GetProperty<Color>("Color");
			}
		}

		public static string GetTriggerName(this NAnalyticEvent ev)
		{
			using (var trigger = ev.Trigger)
			{
				return trigger.GetProperty<string>("Name");
			}
		}

		public static bool IsTriggerTripwire(this NAnalyticEvent ev)
		{
			using (var trigger = ev.Trigger)
			{
				return trigger is NTripwire;
			}
		}
	}
}
