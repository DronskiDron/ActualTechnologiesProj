using ActualTechnologies.Game.State.Buildings;
using ActualTechnologies.Game.State.cmd;
using ActualTechnologies.Game.State.Root;

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
            var entityId = _gameState.GetEntityId();
            var newBuildingEntity = new BuildingEntity
            {
                Id = entityId,
                Position = command.Position,
                TypeId = command.BuildingTypeId
            };

            var newBuildingEntityProxy = new BuildingEntityProxy(newBuildingEntity);
            _gameState.Buildings.Add(newBuildingEntityProxy);

            return true;
        }
    }
}