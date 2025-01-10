using Microsoft.AspNetCore.Components;
using WarframeApiWrapper;
using WarframeApiWrapper.Objects;

namespace WarframeDashboard.Components.VoidTrader
{
    public partial class VoidTrader : ComponentBase
    {
        private WarframeApiWrapper.Objects.VoidTrader? BaroKitten { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var baro = await WarframeApi.GetVoidtrader();
            this.BaroKitten = baro;
        }
    }
}