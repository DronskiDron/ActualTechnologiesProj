using BaCon;

namespace ActualTechnologies.Game.MainMenu.Root.View
{
    public static class MainMenuViewModelsRegistrations
    {
        public static void Register(DIContainer container)
        {
            container.RegisterFactory(c => new UIMainMenuRootViewModel()).AsSingle();
        }
    }
}
