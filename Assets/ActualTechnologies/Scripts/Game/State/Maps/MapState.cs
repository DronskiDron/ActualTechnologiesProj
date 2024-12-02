using System;
using System.Collections.Generic;
using ActualTechnologies.Game.State.Buildings;

namespace ActualTechnologies.Game.State.Maps
{
    [Serializable]
    public class MapState
    {
        public int Id;
        public List<BuildingEntity> Buildings;
    }
}