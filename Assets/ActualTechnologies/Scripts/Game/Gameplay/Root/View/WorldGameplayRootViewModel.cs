using System;
using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.Gameplay.View.Buildings;
using ActualTechnologies.Game.State.GameResources;
using ObservableCollections;
using R3;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ActualTechnologies.Game.Gameplay.Root.View
{
    public class WorldGameplayRootViewModel
    {
        private readonly ResourcesService _resourcesService;
        public readonly IObservableCollection<BuildingViewModel> AllBuildings;


        public WorldGameplayRootViewModel(BuildingsService buildingsService, ResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
            AllBuildings = buildingsService.AllBuildings;

            resourcesService.ObserveResource(ResourceType.SoftCurrency)
                .Subscribe(newValue => Debug.Log($"SoftCurrency: {newValue}"));

            resourcesService.ObserveResource(ResourceType.HardCurrency)
                .Subscribe(newValue => Debug.Log($"HardCurrency: {newValue}"));

            resourcesService.ObserveResource(ResourceType.Wood)
            .Subscribe(newValue => Debug.Log($"Wood: {newValue}"));
        }


        public void HandleTestInput()
        {
            var rResourceType = (ResourceType)Random.Range(0, Enum.GetNames(typeof(ResourceType)).Length);
            var rValue = Random.Range(1, 1000);
            var rOperation = Random.Range(0, 2);

            if (rOperation == 0)
            {
                _resourcesService.AddResources(rResourceType, rValue);
                return;
            }

            _resourcesService.TrySpendResources(rResourceType, rValue);
        }
    }
}
