using System;
using System.IO;

namespace SurveillanceSampleBlazor.Services;

public static class LicensingUtils
{
    public static bool GetTrialModeFlag()
    {
        try
        {
            var flagPath = Path.Combine(AppContext.BaseDirectory, "Licenses", "TrialFlag.txt");
            if (File.Exists(flagPath))
            {
                var text = File.ReadAllText(flagPath).Trim();
                return text.Equals("true", StringComparison.OrdinalIgnoreCase);
            }
        }
        catch
        {
            // ignore errors and treat as not trial
        }
        return false;
    }
}
