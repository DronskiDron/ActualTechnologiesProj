using System;
using ActualTechnologies.Game.GameRoot.Services;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Services
{
    public class SomeGameplayService : IDisposable
    {
        private readonly SomeProjectService _someProjectService;


        public SomeGameplayService(SomeProjectService someProjectService)
        {
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + " has been created");
        }


        public void Dispose()
        {
            Debug.Log("All subscriptions were disposed");
        }
    }
}
