using System.Linq;
using ActualTechnologies.Game.State.Buildings;
using ObservableCollections;
using R3;

namespace ActualTechnologies.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();

        private readonly GameState _gameState;


        public GameStateProxy(GameState gameState)
        {
            gameState.Buildings.ForEach(buildingOrigin => Buildings.Add(new BuildingEntityProxy(buildingOrigin)));

            Buildings.ObserveAdd().Subscribe(e =>
            {
                var addedBuildingEntity = e.Value;
                gameState.Buildings.Add(addedBuildingEntity.Origin);
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity = gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removedBuildingEntity);
            });
            this._gameState = gameState;
        }


        public int GetEntityId()
        {
            return _gameState.GlobalEntityId++;
        }
    }
}
