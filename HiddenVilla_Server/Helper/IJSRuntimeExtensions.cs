using Microsoft.JSInterop;

namespace HiddenVilla_Server.Helper
{
    public static class IJSRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr", "success", message);
            //return await js.InvokeAsync<bool>("confirm", message);
        }
        public static async ValueTask ToastrError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToastr", "error", message);
            //return await js.InvokeAsync<bool>("confirm", message);
        }
        public static async ValueTask SwalSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("SwalAlert", "success", message);
            //return await js.InvokeAsync<bool>("confirm", message);
        }
        public static async ValueTask SwalError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("SwalAlert", "error", message);
            //return await js.InvokeAsync<bool>("confirm", message);
        }
    }
}
