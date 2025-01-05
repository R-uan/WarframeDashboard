using WarframeApiWrapper;
using Microsoft.AspNetCore.Components;

namespace WarframeDashboard.Components.ArchonHunt
{

    public class ArchonImages
    {
        public required string Boss { get; set; }
        public required string Shard { get; set; }
    }
    public partial class ArchonHunt : ComponentBase
    {
        private WarframeApiWrapper.ArchonHunt? Arch;
        private Dictionary<string, ArchonImages> ArchonImages = new() {
            {
                "Archon Amar" ,
                new() {
                    Boss = "https://static.wikia.nocookie.net/warframe/images/b/be/ArchonAmar.png",
                    Shard = "https://static.wikia.nocookie.net/warframe/images/0/0e/CrimsonArchonShard.png"
                }
            },
            {
                "Archon Boreal",
                new() {
                    Boss = "https://static.wikia.nocookie.net/warframe/images/1/1c/ArchonBoreal.png/",
                    Shard = "https://static.wikia.nocookie.net/warframe/images/9/93/AzureArchonShard.png/"
                }
            },
            {
                "Archon Nira",
                new() {
                    Boss = "https://static.wikia.nocookie.net/warframe/images/4/4c/ArchonNira.png",
                    Shard = "https://static.wikia.nocookie.net/warframe/images/d/de/AmberArchonShard.png"
                }
            },
        };


        protected override async Task OnInitializedAsync()
        {
            var hunt = await WarframeApi.GetArchonHunt();
            this.Arch = hunt;
        }
    }
}