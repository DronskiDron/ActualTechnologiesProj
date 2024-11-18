using System;
using System.Linq;
using ActualTechnologies.Game.GameRoot.Services;
using ActualTechnologies.Game.State.Buildings;
using ActualTechnologies.Game.State.Root;
using ObservableCollections;
using R3;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly GameStateProxy _gameState;
        private readonly SomeProjectService _someProjectService;


        public SomeGameplayService(GameStateProxy gameState, SomeProjectService someProjectService)
        {
            _gameState = gameState;
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + " has been created");

            gameState.Buildings.ForEach(b => Debug.Log($"Building: {b.TypeId}"));
            gameState.Buildings.ObserveAdd().Subscribe(e => Debug.Log($"Building added:{e.Value.TypeId}"));
            gameState.Buildings.ObserveRemove().Subscribe(e => Debug.Log($"Building removed:{e.Value.TypeId}"));

            AddBuilding("First Building");
            AddBuilding("Second Building");
            AddBuilding("Third Building");

            RemoveBuilding("Second Building");
        }


        public void Dispose()
        {
            Debug.Log("All subscriptions were disposed");
        }


        private void AddBuilding(string buildingTypeId)
        {
            var building = new BuildingEntity
            {
                TypeId = buildingTypeId
            };

            var buildingProxy = new BuildingEntityProxy(building);
            _gameState.Buildings.Add(buildingProxy);
        }


        private void RemoveBuilding(string buildingTypeId)
        {
            var buildingEntity = _gameState.Buildings.FirstOrDefault(b => b.TypeId == buildingTypeId);

            if (buildingEntity != null)
            {
                _gameState.Buildings.Remove(buildingEntity);
            }
        }
    }
}
