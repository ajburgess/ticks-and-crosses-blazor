using Microsoft.JSInterop;

namespace TicksBlazorWebAssembly.Client.Services;

public class BrowserService
{
    private IJSRuntime _js;

    public BrowserService(IJSRuntime js)
    {
        _js = js;
    }

    /// <summary>
    /// Get a unique ID for this browser.
    /// The value will be the same for all tabs.
    /// </summary>
    /// <returns>Browser ID</returns>
    public async Task<string> GetBrowserId()
    {
        string? id = await _js.InvokeAsync<string>("getBrowserId");
        if (id is null)
        {
            id = Guid.NewGuid().ToString();
            await _js.InvokeVoidAsync("setBrowserId", id);
        }
        return id;
    }

    /// <summary>
    /// Play a beep sound in this browser tab.
    /// </summary>
    public async Task PlayBeep()
    {
        await _js.InvokeVoidAsync("playBeep");
    }
}
