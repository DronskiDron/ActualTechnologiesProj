using System;
using ActualTechnologies.Game.GameRoot;
using ActualTechnologies.Game.MainMenu.Root.View;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public class MainMenuEntryPoint : MonoBehaviour
    {
        public event Action GoToGameplaySceneRequested;

        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;


        public void Run(UIRootView UIRoot)
        {
            var UIScene = Instantiate(_sceneUIRootPrefab);
            UIRoot.AttachSceneUI(UIScene.gameObject);

            UIScene.GoToGameplayButtonClicked += () =>
            {
                GoToGameplaySceneRequested?.Invoke();
            };
        }
    }
}
