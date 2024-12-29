using ActualTechnologies.Game.State.GameResources;
using R3;

namespace ActualTechnologies.Game.Gameplay.View.GameResources
{
    public class ResourceViewModel
    {
        public readonly ResourceType ResourceType;
        public readonly ReadOnlyReactiveProperty<int> Amount;

        public ResourceViewModel(Resource resource)
        {
            ResourceType = resource.ResourceType;
            Amount = resource.Amount;
        }
    }
}