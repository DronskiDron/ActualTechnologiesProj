using ActualTechnologies.Game.State.cmd;

namespace ActualTechnologies.Game.Gameplay.Commands
{
    public class CmdCreateMapState : ICommand
    {
        public readonly int MapId;


        public CmdCreateMapState(int mapId)
        {
            MapId = mapId;
        }
    }
}