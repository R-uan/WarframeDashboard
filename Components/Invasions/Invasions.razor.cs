using System.Text.Json;
using Microsoft.AspNetCore.Components;
using WarframeApiWrapper;
using WarframeApiWrapper.Objects;

namespace WarframeDashboard.Components.Invasions
{
    public partial class Invasions : ComponentBase
    {
        private List<Invasion>? InvasionList;
        private Dictionary<Faction, string> FactionIcons = new()
        {
            { Faction.Infested, "https://static.wikia.nocookie.net/warframe/images/7/76/DeimosInfested.png" },
            { Faction.Grineer, "https://static.wikia.nocookie.net/warframe/images/8/8a/IconGrineerOn.png/" },
            { Faction.Corpus, "https://static.wikia.nocookie.net/warframe/images/b/b2/IconCorpusOn.png/" }
        };

        protected override async Task OnInitializedAsync()
        {
            System.Console.WriteLine("Invasions Initialization");
            var invasions = await WarframeApi.GetInvasions();
            this.InvasionList = invasions;
        }
    }
}