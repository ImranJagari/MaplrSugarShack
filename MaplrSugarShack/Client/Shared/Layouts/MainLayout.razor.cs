using Microsoft.JSInterop;

namespace MaplrSugarShack.Client.Shared.Layouts
{
    public partial class MainLayout
    {
        public bool mustRefreshJs;
        protected override Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
            return base.OnInitializedAsync();
        }

        private void OnLocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            mustRefreshJs = true;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender || mustRefreshJs)
            {
                await Js.InvokeVoidAsync("loadMainScript");
                mustRefreshJs = false;
            }
        }

    }
}