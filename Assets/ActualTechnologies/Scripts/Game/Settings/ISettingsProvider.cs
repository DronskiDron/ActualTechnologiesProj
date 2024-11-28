using System.Threading.Tasks;

namespace ActualTechnologies.Game.Settings
{
    public interface ISettingsProvider
    {
        GameSettings GameSettings { get; }
        ApplicationSettings ApplicationSettings { get; }


        Task<GameSettings> LoadGameSettings();
    }
}