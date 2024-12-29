using ActualTechnologies.Game.State.cmd;
using ActualTechnologies.Game.State.GameResources;

namespace ActualTechnologies.Game.Gameplay.Commands
{
    public class CmdResourcesSpend : ICommand
    {
        public readonly ResourceType ResourceType;
        public readonly int Amount;


        public CmdResourcesSpend(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
    }
}