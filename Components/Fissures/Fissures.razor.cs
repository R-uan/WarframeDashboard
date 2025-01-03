using Microsoft.AspNetCore.Components;
using WarframeApiWrapper;
using WarframeApiWrapper.Objects;

namespace WarframeDashboard.Components.Fissures
{
    public partial class Fissures : ComponentBase
    {
        public delegate void FilterEvent();
        public event FilterEvent FilterEventHandlers;
        public List<Fissure>? FissureList { get; set; }
        public List<Fissure>? FissureFiltered { get; set; }
        private FissuresFilter FissuresFilter { get; } = new FissuresFilter();

        public Dictionary<FissureTier, string> FissureImages = new() {
            { FissureTier.Lith, "https://static.wikia.nocookie.net/warframe/images/d/df/LithRelicIntact.png" },
            { FissureTier.Meso, "https://static.wikia.nocookie.net/warframe/images/e/e0/MesoRelicIntact.png"},
            { FissureTier.Neo, "https://static.wikia.nocookie.net/warframe/images/9/97/NeoRelicIntact.png"},
            { FissureTier.Axi, "https://static.wikia.nocookie.net/warframe/images/b/bd/AxiRelicIntact.png"},
            { FissureTier.Requiem, "https://static.wikia.nocookie.net/warframe/images/d/da/RequiemRelicIntact.png"},
            { FissureTier.Omnia, "https://static.wikia.nocookie.net/warframe/images/b/bd/AxiRelicIntact.png"},
        };

        private void ApplyFilter()
        {
            System.Console.WriteLine("Apply Filter");
            var placeholder = this.FissureList;
            if (this.FissuresFilter.FissureTier != null && placeholder != null)
                placeholder = placeholder.Where(fissure => fissure.Tier == this.FissuresFilter.FissureTier).ToList();
            if (this.FissuresFilter.SteelPathFilter == true && placeholder != null)
                placeholder = placeholder.Where(fissure => fissure.IsSteelPath == true).ToList();
            this.FissureFiltered = placeholder;
            StateHasChanged();
        }

        private void TierSelectionChange(ChangeEventArgs e)
        {
            var selectedValue = e.Value?.ToString();
            if (selectedValue != null && this.FissureList != null)
                this.FissuresFilter.FissureTier = selectedValue switch
                {
                    "lith" => FissureTier.Lith,
                    "meso" => FissureTier.Meso,
                    "neo" => FissureTier.Neo,
                    "axi" => FissureTier.Axi,
                    "requiem" => FissureTier.Requiem,
                    "omnia" => FissureTier.Omnia,
                    _ => null,
                };
            this.FilterEventHandlers?.Invoke();
        }

        private void SteelPathSelectionChange(ChangeEventArgs e)
        {
            var selectedValue = e.Value;
            if ((bool)selectedValue! == true)
                this.FissuresFilter.SteelPathFilter = true;
            else
                this.FissuresFilter.SteelPathFilter = false;
            this.FilterEventHandlers?.Invoke();
        }

        protected override async Task OnInitializedAsync()
        {
            this.FilterEventHandlers += this.ApplyFilter;
            var fissures = await WarframeApi.GetFissures();
            fissures = [.. fissures.OrderBy(a => a.Tier switch
                {
                    FissureTier.Lith => 0,
                    FissureTier.Meso => 1,
                    FissureTier.Neo => 2,
                    FissureTier.Axi => 3,
                    FissureTier.Requiem => 4,
                    FissureTier.Omnia => 5,
                    _ => 6
                })
            ];

            this.FissureList = fissures;
            this.FissureFiltered = fissures;
        }
    }

    public class FissuresFilter
    {
        public bool SteelPathFilter { get; set; } = false;
        public FissureTier? FissureTier { get; set; }
    }
}