using ActualTechnologies.Game.Gameplay.Root;
using ActualTechnologies.Game.GameRoot;
using ActualTechnologies.Game.MainMenu.Root.View;
using BaCon;
using R3;
using UnityEngine;

namespace ActualTechnologies.Game.MainMenu.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;


        public Observable<MainMenuExitParams> Run(DIContainer mainMenuContainer, MainMenuEnterParams enterParams)
        {
            MainMenuRegistrations.Register(mainMenuContainer, enterParams);
            var mainMenuViewModelsContainer = new DIContainer(mainMenuContainer);
            MainMenuViewModelsRegistrations.Register(mainMenuViewModelsContainer);

            //For test
            mainMenuViewModelsContainer.Resolve<UIMainMenuRootViewModel>();

            var UIRoot = mainMenuContainer.Resolve<UIRootView>();
            var UIScene = Instantiate(_sceneUIRootPrefab);
            UIRoot.AttachSceneUI(UIScene.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            UIScene.Bind(exitSceneSignalSubj);

            Debug.Log($"MAIN MENU ENTRY POINT: Run main menu scene. Results: {enterParams?.Result}");

            var saveFileName = "MyTest.save";
            var levelNumber = Random.Range(0, 200);

            var gameplayEnterParams = new GameplayEnterParams(saveFileName, levelNumber);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            var exitToGameplaySceneSignal = exitSceneSignalSubj.Select(_ => mainMenuExitParams);

            return exitToGameplaySceneSignal;
        }
    }
}
