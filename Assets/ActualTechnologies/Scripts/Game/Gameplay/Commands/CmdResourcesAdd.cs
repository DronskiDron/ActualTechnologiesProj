
using ActualTechnologies.Game.State.cmd;
using ActualTechnologies.Game.State.GameResources;

namespace ActualTechnologies.Game.Gameplay.Commands
{
    public class CmdResourcesAdd : ICommand
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;


        public CmdResourcesAdd(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}