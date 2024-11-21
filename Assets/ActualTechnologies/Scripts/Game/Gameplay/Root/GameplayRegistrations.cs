using ActualTechnologies.Game.Gameplay.Commands;
using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.State;
using ActualTechnologies.Game.State.cmd;
using BaCon;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public static class GameplayRegistrations
    {
        public static void Register(DIContainer container, GameplayEnterParams gameplayEnterParams)
        {
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;

            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);

            container.RegisterFactory(_ => new BuildingsService(gameState.Buildings, cmd)).AsSingle();
        }
    }
}
