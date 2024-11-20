using System;
using System.Collections.Generic;
using ActualTechnologies.Game.State.Buildings;

namespace ActualTechnologies.Game.State.Root
{
    [Serializable]
    public class GameState
    {
        public int GlobalEntityId;
        public List<BuildingEntity> Buildings;
    }
}