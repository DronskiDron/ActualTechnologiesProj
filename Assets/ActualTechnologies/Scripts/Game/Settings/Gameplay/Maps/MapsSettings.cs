using System.Collections.Generic;
using UnityEngine;

namespace ActualTechnologies.Game.Settings.Gameplay.Maps
{
    [CreateAssetMenu(fileName = "Game Settings/Maps/New Maps Settings")]
    public class MapsSettings : ScriptableObject
    {
        public List<MapSettings> Maps;
    }
}