using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.State.Buildings;

namespace ActualTechnologies.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private BuildingEntityProxy _buildingEntity;
        private BuildingsService _buildingsService;


        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            _buildingEntity = buildingEntity;
            _buildingsService = buildingsService;
        }
    }
}