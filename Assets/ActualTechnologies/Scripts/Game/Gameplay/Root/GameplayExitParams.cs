using ActualTechnologies.Game.MainMenu.Root;

namespace ActualTechnologies.Game.Gameplay.Root
{
    public class GameplayExitParams
    {
        public MainMenuEnterParams MainMenuEnterParams { get; }


        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams)
        {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}
