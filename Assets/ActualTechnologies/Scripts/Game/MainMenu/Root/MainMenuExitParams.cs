using ActualTechnologies.Game.GameRoot;

namespace ActualTechnologies.Game.MainMenu.Root
{
    public class MainMenuExitParams
    {
        public SceneEnterParams TargetSceneEnterParams { get; }


        public MainMenuExitParams(SceneEnterParams targetSceneEnterPasrams)
        {
            TargetSceneEnterParams = targetSceneEnterPasrams;
        }
    }
}
