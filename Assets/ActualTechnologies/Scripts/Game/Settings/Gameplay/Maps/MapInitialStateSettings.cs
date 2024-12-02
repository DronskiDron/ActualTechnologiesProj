using System;
using System.Collections.Generic;
using ActualTechnologies.Game.Settings.Gameplay.Buildings;

namespace ActualTechnologies.Game.Settings.Gameplay.Maps
{
    [Serializable]
    public class MapInitialStateSettings
    {
        public List<BuildingInitialStateSettings> Buildings;
    }
}