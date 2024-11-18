using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.GameRoot.Services;
using ActualTechnologies.Game.State;
using BaCon;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            container.RegisterFactory(c => new SomeGameplayService(
                c.Resolve<IGameStateProvider>().GameState,
                c.Resolve<SomeProjectService>())).AsSingle();
        }
    }
}
