using ActualTechnologies.Game.Gameplay.Root.View;
using ActualTechnologies.Game.GameRoot;
using ActualTechnologies.Game.MainMenu.Root;
using BaCon;
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
    }
}
