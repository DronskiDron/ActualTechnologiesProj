using ActualTechnologies.Game.GameRoot.Services;
using ActualTechnologies.Game.MainMenu.Services;
using BaCon;

namespace ActualTechnologies.Game.MainMenu.Root
{
    public static class MainMenuRegistrations
    {
        public static void Register(DIContainer container, MainMenuEnterParams mainMenuEnterParams)
        {
            container.RegisterFactory(c => new SomeMainMenuService(c.Resolve<SomeProjectService>())).AsSingle();
        }
    }
}

