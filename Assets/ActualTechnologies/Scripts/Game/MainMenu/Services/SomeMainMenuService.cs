using ActualTechnologies.Game.GameRoot.Services;
using UnityEngine;

namespace ActualTechnologies.Game.MainMenu.Services
{
    public class SomeMainMenuService
    {
        private readonly SomeProjectService _someProjectService;


        public SomeMainMenuService(SomeProjectService someProjectService)
        {
            _someProjectService = someProjectService;
            Debug.Log(GetType().Name + " has been created");
        }
    }
}
