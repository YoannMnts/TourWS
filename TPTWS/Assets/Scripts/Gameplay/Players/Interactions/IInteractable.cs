using UnityEngine;

namespace TPT.Gameplay.Player
{
	public interface IInteractable
	{
		public int Priority { get; }
		Transform transform { get; }
		void Interact();
	}
}