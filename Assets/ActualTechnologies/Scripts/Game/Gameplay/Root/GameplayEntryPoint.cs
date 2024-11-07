using UnityEngine;

namespace ActualTechnologies.Game.Gameplay
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private GameObject _sceneRootBinder;


        public void Run()
        {
            Debug.Log("Gameplay scene loaded");
        }
    }
}
