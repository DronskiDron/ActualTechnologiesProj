using ActualTechnologies.Game.GameRoot;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public class GameplayEnterParams : SceneEnterParams
    {
        public int MapId { get; }


        public GameplayEnterParams(int mapId) : base(Scenes.GAMEPLAY)
        {
            MapId = mapId;
        }
    }
}

