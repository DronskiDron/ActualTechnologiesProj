using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.GameRoot.Services;
using BaCon;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(c.Resolve<SomeProjectService>())).AsSingle();
        }
    }
}
