using UnityEngine;

namespace TPT.Gameplay.Players.Interactions
{
	public interface IInteractable
	{
		public int Priority { get; }
		Transform transform { get; }
		void Interact();
	}
}