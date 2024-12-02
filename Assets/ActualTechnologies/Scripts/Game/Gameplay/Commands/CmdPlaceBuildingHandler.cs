using System.Linq;
using ActualTechnologies.Game.State.Buildings;
using ActualTechnologies.Game.State.cmd;
using ActualTechnologies.Game.State.Root;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Commands
{
    public class CmdPlaceBuildingHandler : ICommandHandler<CmdPlaceBuilding>
    {
        private GameStateProxy _gameState;

        public CmdPlaceBuildingHandler(GameStateProxy gameState)
        {
            _gameState = gameState;
        }


        public bool Handle(CmdPlaceBuilding command)
        {
            var currentMap = _gameState.Maps.FirstOrDefault(m => m.Id == _gameState.CurrentMapId.CurrentValue);

            if (currentMap == null)
            {
                Debug.LogError($"Couldn't find MapState for Id{_gameState.CurrentMapId.CurrentValue}");
                return false;
            }

            var entityId = _gameState.CreateEntityId();
            var newBuildingEntity = new BuildingEntity
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);

            currentMap.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}