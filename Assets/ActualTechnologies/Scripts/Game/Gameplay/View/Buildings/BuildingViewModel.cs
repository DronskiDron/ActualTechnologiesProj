using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.State.Buildings;
using R3;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.View.Buildings
{
    public class BuildingViewModel
    {
        private BuildingEntityProxy _buildingEntity;
        private BuildingsService _buildingsService;

        public readonly int BuildingEntityId;
        public ReadOnlyReactiveProperty<Vector3Int> Position { get; }


        public BuildingViewModel(BuildingEntityProxy buildingEntity, BuildingsService buildingsService)
        {
            BuildingEntityId = buildingEntity.Id;

            _buildingEntity = buildingEntity;
            _buildingsService = buildingsService;

            Position = buildingEntity.Position;
        }
    }
}