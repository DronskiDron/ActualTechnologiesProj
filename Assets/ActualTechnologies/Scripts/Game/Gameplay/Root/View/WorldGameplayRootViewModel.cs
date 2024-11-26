using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.Gameplay.View.Buildings;
using ObservableCollections;

namespace ActualTechnologies.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;


        public WorldGameplayRootViewModel(BuildingsService buildingsService)
        {
            AllBuildings = buildingsService.AllBuildings;
        }
    }
}
