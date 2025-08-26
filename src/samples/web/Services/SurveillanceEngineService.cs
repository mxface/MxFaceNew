using System.Threading.Tasks;
using Neurotec.Surveillance;

namespace SurveillanceSampleBlazor.Services;

public class SurveillanceEngineService : IAsyncDisposable
{
    private readonly SentiVeillanceService _licenseService;
    private NSurveillanceEngine? _engine;

    public SurveillanceEngineService(SentiVeillanceService licenseService)
    {
        _licenseService = licenseService;
    }

    public async Task<bool> StartAsync()
    {
        var status = await _licenseService.EnsureLicensesAsync();
        if (!status.AnyComponentLicensed)
        {
            return false;
        }

        _engine ??= new NSurveillanceEngine();
        _engine.Start();
        return true;
    }

    public void Stop()
    {
        _engine?.Stop();
    }

    public ValueTask DisposeAsync()
    {
        _engine?.Dispose();
        return ValueTask.CompletedTask;
    }
}

