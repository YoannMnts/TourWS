using System;
using TPT.Gameplay.PNJs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
	public class PlayerInteractions : MonoBehaviour
	{
		private PNJ current;

		public void OnInteractInput(InputAction.CallbackContext context)
		{
			if(current != null)
				current.Interact();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out PNJ pnj))
			{
				if(current && pnj.Priority < current.Priority)
					return;
				
				current = pnj;
				IconPNJ.Instance.SetCurrentNPC(current);
			}
		}
		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent(out PNJ pnj))
			{
				if(current != pnj)
					return;
				
				current = null;
				IconPNJ.Instance.ClearCurrent();
			}
		}
	}
}