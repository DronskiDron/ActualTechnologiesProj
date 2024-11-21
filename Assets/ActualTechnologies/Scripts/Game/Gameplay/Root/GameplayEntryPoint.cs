using ActualTechnologies.Game.Gameplay.Root.View;
using ActualTechnologies.Game.Gameplay.Services;
using ActualTechnologies.Game.GameRoot;
using ActualTechnologies.Game.MainMenu.Root;
using ActualTechnologies.Game.State;
using BaCon;
using ObservableCollections;
using R3;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;


        public Observable<GameplayExitParams> Run(DIContainer gameplayContainer, GameplayEnterParams enterParams)
        {
            GameplayRegistrations.Register(gameplayContainer, enterParams);
            var gameplayViewModelsContainer = new DIContainer(gameplayContainer);
            GameplayViewModelsRegistrations.Register(gameplayViewModelsContainer);

            ///Command Processor Test
            var gameStateProvider = gameplayContainer.Resolve<IGameStateProvider>();

            gameStateProvider.GameState.Buildings.ObserveAdd().Subscribe(e =>
            {
                var building = e.Value;
                Debug.Log("Building placed.Type id: " +
                building.TypeId
                + " Id: " + building.Id
                + ", Position: " +
                building.Position.Value);
            });

            var buildingsService = gameplayContainer.Resolve<BuildingsService>();

            buildingsService.PlaceBuilding("MyAwesomBuilding", GetRandomPosition());
            buildingsService.PlaceBuilding("MySecondAwesomBuilding", GetRandomPosition());
            buildingsService.PlaceBuilding("MyThirdAwesomBuilding", GetRandomPosition());

            //For test
            gameplayViewModelsContainer.Resolve<UIGameplayRootViewModel>();
            gameplayViewModelsContainer.Resolve<WorldGameplayRootViewModel>();

            var UIRoot = gameplayContainer.Resolve<UIRootView>();
            var UIScene = Instantiate(_sceneUIRootPrefab);
            UIRoot.AttachSceneUI(UIScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            UIScene.Bind(exitSceneSignalSubj);

            Debug.Log($"GAMEPLAY ENTRY POINT: save file name = {enterParams.SaveFileName}, level to load = {enterParams.LevelNumber}");

            var mainMenuEnterParams = new MainMenuEnterParams("My random string");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);

            return exitToMainMenuSceneSignal;
        }


        private Vector3Int GetRandomPosition()
        {
            var rX = Random.Range(-10, 10);
            var rY = Random.Range(-10, 10);
            var rPosition = new Vector3Int(rX, rY, 0);

            return rPosition;
        }
    }
}
