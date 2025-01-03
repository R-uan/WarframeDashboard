using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using WarframeApiWrapper;
using WarframeApiWrapper.Objects;

namespace WarframeDashboard.Components.WorldStatus
{
    public partial class WorldStatus : ComponentBase
    {
        public CetusStatus? CetusStatus { get; set; }
        public OrbVallisStatus? VenusStatus { get; set; }
        public CambionDriftStatus? DeimosStatus { get; set; }

        public async Task GetCetusStatus()
        {
            var cetusStatus = await WarframeApi.GetCetusStatus();
            if (cetusStatus != null) this.CetusStatus = cetusStatus;
            else this.CetusStatus = null;
        }

        public async Task GetVenusStatus()
        {
            var venusStatus = await WarframeApi.GetVallisStatus();
            if (venusStatus != null) this.VenusStatus = venusStatus;
            else this.VenusStatus = null;
        }

        public async Task GetDeimosStatus()
        {
            var deimosStatus = await WarframeApi.GetDeimosStatus();
            if (deimosStatus != null) this.DeimosStatus = deimosStatus;
            else this.DeimosStatus = deimosStatus;
        }

        protected override async Task OnInitializedAsync()
        {
            await this.GetCetusStatus();
            await this.GetVenusStatus();
            await this.GetDeimosStatus();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                this.TimezoneService.SetTimezone(await JS.InvokeAsync<string>("getTimeZone"));
                StateHasChanged();
            }
        }
    }
}