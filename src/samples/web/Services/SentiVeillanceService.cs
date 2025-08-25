using Neurotec.Licensing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SurveillanceSampleBlazor.Services;

public class SentiVeillanceService : IAsyncDisposable
{
    private readonly string[] _components = new[] { "SentiVeillanceVH", "SentiVeillanceALPR", "SentiVeillance" };
    private readonly List<string> _obtained = new();
    private LicenseStatus? _cachedStatus;

    public async Task<LicenseStatus> EnsureLicensesAsync()
    {
        if (_cachedStatus is not null)
        {
            return _cachedStatus;
        }

        _cachedStatus = await Task.Run(() =>
        {
            var status = new LicenseStatus();
            status.TrialMode = LicensingUtils.GetTrialModeFlag();
            NLicenseManager.TrialMode = status.TrialMode;

            try
            {
                foreach (var component in _components)
                {
                    bool obtained = NLicense.Obtain("/local", 5000, component);
                    status.Components[component] = obtained;
                    status.AnyComponentLicensed |= obtained;
                    if (obtained)
                    {
                        _obtained.Add(component);
                    }
                }

                if (!status.AnyComponentLicensed)
                {
                    status.Error = $"Could not obtain licenses for any of components: {string.Join(", ", _components)}";
                }
            }
            catch (Exception ex)
            {
                status.Error = $"Failed to obtain licenses for components.\nError message: {ex.Message}";
                if (ex is IOException)
                {
                    status.Error += "\n(Probably licensing service is not running. Use Activation Wizard to figure it out.)";
                }
            }

            return status;
        });

        return _cachedStatus;
    }

    public ValueTask DisposeAsync()
    {
        foreach (var component in _obtained)
        {
            try
            {
                NLicense.Release(component);
            }
            catch
            {
                // ignore release errors
            }
        }

        return ValueTask.CompletedTask;
    }
}
