using System;
using ActualTechnologies.Game.Gameplay.Root.View;
using ActualTechnologies.Game.GameRoot;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public event Action GoToMainMenuSceneRequested;

        [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;


        public void Run(UIRootView UIRoot)
        {
            var UIScene = Instantiate(_sceneUIRootPrefab);
            UIRoot.AttachSceneUI(UIScene.gameObject);

            UIScene.GoToMainMenuButtonClicked += () =>
            {
                GoToMainMenuSceneRequested?.Invoke();
            };
        }
    }
}
