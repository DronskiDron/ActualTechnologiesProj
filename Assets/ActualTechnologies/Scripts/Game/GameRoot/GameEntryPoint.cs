using System.Collections;
using ActualTechnologies.Game.Gameplay.Root;
using ActualTechnologies.Game.MainMenu.Root;
using ActualTechnologies.Utils;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ActualTechnologies.Game.GameRoot
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _UIRoot;


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _instance = new GameEntryPoint();
            _instance.RunGame();
        }


        private GameEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            _UIRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_UIRoot.gameObject);
        }


        private void RunGame()
        {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == Scenes.GAMEPLAY)
            {
                var enterParams = new GameplayEnterParams("Second.save", 1);
                _coroutines.StartCoroutine(LoadAndStartGameplay(enterParams));
                return;
            }

            if (sceneName == Scenes.MAIN_MENU)
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                return;
            }

            if (sceneName != Scenes.BOOT)
            {
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }


        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams)
        {
            _UIRoot.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);

            yield return new WaitForSeconds(1f);

            var sceneEntryPoint = Object.FindObjectOfType<GameplayEntryPoint>();
            sceneEntryPoint.Run(_UIRoot, enterParams).Subscribe(gameplayExitParams =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
            });

            _UIRoot.HideLoadingScreen();
        }


        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null)
        {
            _UIRoot.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);

            yield return new WaitForSeconds(1f);

            var sceneEntryPoint = Object.FindObjectOfType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(_UIRoot, enterParams).Subscribe(mainMenuExitParams =>
            {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;

                if (targetSceneName == Scenes.GAMEPLAY)
                {
                    _coroutines.StartCoroutine(LoadAndStartGameplay(mainMenuExitParams.TargetSceneEnterParams.
                    As<GameplayEnterParams>()));
                }
            });

            _UIRoot.HideLoadingScreen();
        }


        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}

