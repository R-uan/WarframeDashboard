using Microsoft.AspNetCore.Components;
using WarframeApiWrapper;
using WarframeApiWrapper.Objects;

namespace WarframeDashboard.Components.Sortie
{
    public partial class Sortie : ComponentBase
    {
        private WarframeApiWrapper.Objects.Sortie? Sortied { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var sortie = await WarframeApi.GetSortie();
            this.Sortied = sortie;
        }
    }
}