using System;
using UnityEngine;

namespace ActualTechnologies.Game.MainMenu.Root.View
{
    public class UIMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayButtonClicked;


        public void HandleGoToGameplayButtonClick()
        {
            GoToGameplayButtonClicked?.Invoke();
        }
    }
}
