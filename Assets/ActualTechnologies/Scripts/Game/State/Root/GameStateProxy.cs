using System.Linq;
using ActualTechnologies.Game.State.Buildings;
using ObservableCollections;
using R3;

namespace ActualTechnologies.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<BuildingEntityProxy> Buildings { get; } = new();


        public GameStateProxy(GameState gameState)
        {
            gameState.Buildings.ForEach(buildingOrigin => Buildings.Add(new BuildingEntityProxy(buildingOrigin)));

            Buildings.ObserveAdd().Subscribe(e =>
            {
                var eddedBuildingEntity = e.Value;
                gameState.Buildings.Add(new BuildingEntity
                {
                    Id = eddedBuildingEntity.Id,
                    TypeId = eddedBuildingEntity.TypeId,
                    Level = eddedBuildingEntity.Level.Value,
                    Position = eddedBuildingEntity.Position.Value,
                });
            });

            Buildings.ObserveRemove().Subscribe(e =>
            {
                var removedBuildingEntityProxy = e.Value;
                var removedBuildingEntity = gameState.Buildings.FirstOrDefault(b => b.Id == removedBuildingEntityProxy.Id);
                gameState.Buildings.Remove(removedBuildingEntity);
            });
        }
    }
}
