using UnityEngine;

namespace TPT.Gameplay.Players.Interactions
{
	public interface IInteractable
	{
		Transform transform { get; }
		void Interact();
	}
}