using ActualTechnologies.Game.Gameplay.Services;

namespace ActualTechnologies.Game.Gameplay.Root.View
{
    public class UIGameplayRootViewModel
    {
        private readonly SomeGameplayService _someGameplayService;


        public UIGameplayRootViewModel(SomeGameplayService someGameplayService)
        {
            _someGameplayService = someGameplayService;
        }
    }
}
