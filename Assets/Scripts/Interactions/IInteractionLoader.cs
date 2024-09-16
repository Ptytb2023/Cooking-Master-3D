using Player;
using System;

namespace Interactions
{
    public interface IInteractionLoader
    {
        event Action<PlayerInteractor> PlayerInteractСompleted;

        void StartInteraction(PlayerInteractor playerInteractor, float timeInterection);
        void StopInteraction();
    }
}