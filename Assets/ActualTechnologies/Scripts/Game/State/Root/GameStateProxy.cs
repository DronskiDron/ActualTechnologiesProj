using System.Linq;
using ActualTechnologies.Game.State.Maps;
using ObservableCollections;
using R3;

namespace ActualTechnologies.Game.State.Root
{
    public class GameStateProxy
    {
        public ObservableList<Map> Maps { get; } = new();
        public readonly ReactiveProperty<int> CurrentMapId = new();

        private readonly GameState _gameState;


        public GameStateProxy(GameState gameState)
        {
            _gameState = gameState;
            gameState.Maps.ForEach(mapOrigin => Maps.Add(new Map(mapOrigin)));

            Maps.ObserveAdd().Subscribe(e =>
            {
                var addedMap = e.Value;
                gameState.Maps.Add(addedMap.Origin);
            });

            Maps.ObserveRemove().Subscribe(e =>
            {
                var removedMap = e.Value;
                var removedMupState = gameState.Maps.FirstOrDefault(b => b.Id == removedMap.Id);
                gameState.Maps.Remove(removedMupState);
            });

            CurrentMapId.Subscribe(newValue => { gameState.CurrentMapId = newValue; });
        }


        public int CreateEntityId()
        {
            return _gameState.CreateEntityId();
        }
    }
}
