using ActualTechnologies.Game.Gameplay.Services;
using BaCon;

namespace ActualTechnologies.Game.Gameplay.Root.View
{
    public static class GameplayViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIGameplayRootViewModel()).AsSingle();
            container
            .RegisterFactory(c => new WorldGameplayRootViewModel(
                container.Resolve<BuildingsService>(),
                container.Resolve<ResourcesService>()))
            .AsSingle();
        }
    }
}
