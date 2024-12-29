using System;
using System.Linq;
using ActualTechnologies.Game.Gameplay.Commands;
using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.Settings;
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
            var settingsProvider = container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;

            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceBuildingHandler(gameState));
            cmd.RegisterHandler(new CmdCreateMapStateHandler(gameState, gameSettings));
            cmd.RegisterHandler(new CmdResourcesAddHandler(gameState));
            cmd.RegisterHandler(new CmdResourcesSpendHandler(gameState));
            container.RegisterInstance<ICommandProcessor>(cmd);

            var loadingMapId = gameplayEnterParams.MapId;
            var loadingMap = gameState.Maps.FirstOrDefault(m => m.Id == loadingMapId);

            if (loadingMap == null)
            {
                var command = new CmdCreateMapState(loadingMapId);
                var success = cmd.Process(command);

                if (!success)
                {
                    throw new Exception($"Couldn't create map state with id: ${loadingMapId}");
                }

                loadingMap = gameState.Maps.First(m => m.Id == loadingMapId);
            }

            container.RegisterFactory(_ => new BuildingsService(loadingMap.Buildings,
            gameSettings.BuildingsSettings,
            cmd)).AsSingle();

            container.RegisterFactory(_ => new ResourcesService(gameState.Resources, cmd)).AsSingle();
        }
    }
}
