namespace SurveillanceSampleBlazor.Services;

using System.Collections.Generic;

public class LicenseStatus
{
    public bool TrialMode { get; set; }
    public bool AnyComponentLicensed { get; set; }
    public Dictionary<string, bool> Components { get; } = new();
    public string? Error { get; set; }
}
