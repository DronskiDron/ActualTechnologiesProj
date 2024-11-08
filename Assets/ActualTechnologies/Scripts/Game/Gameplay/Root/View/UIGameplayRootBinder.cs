using System;
using UnityEngine;

namespace ActualTechnologies.Game.Gameplay.Root.View
{
    public class UIGameplayRootBinder : MonoBehaviour
    {
        public event Action GoToMainMenuButtonClicked;


        public void HandleGoToMainMenuButtonClick()
        {
            GoToMainMenuButtonClicked?.Invoke();
        }
    }
}
