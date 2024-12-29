using System;
using System.Collections.Generic;
using ActualTechnologies.Game.State.GameResources;
using ActualTechnologies.Game.State.Maps;

namespace ActualTechnologies.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public int CurrentMapId;
        public List<MapState> Maps;
        public List<ResourceData> Resources;


        public int CreateEntityId()
        {
            return GlobalEntityId++;
        }
    }
}