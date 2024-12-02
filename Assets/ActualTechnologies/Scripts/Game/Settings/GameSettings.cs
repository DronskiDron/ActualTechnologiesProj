using ActualTechnologies.Game.Settings.Gameplay.Buildings;
using ActualTechnologies.Game.Settings.Gameplay.Maps;
using UnityEngine;

namespace ActualTechnologies.Game.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings/New Game Settings")]
    public class GameSettings : ScriptableObject
    {
        public BuildingsSettings BuildingsSettings;
        public MapsSettings MapsSettings;
    }
}