using System;
using TPT.Gameplay.PNJs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
	public class PlayerInteractions : MonoBehaviour
	{
		private IInteractable current;

		public void OnInteractInput(InputAction.CallbackContext context)
		{
			if(current != null)
				current.Interact();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				Debug.Log(interactable.transform.name, interactable.transform);
				if(current != null && interactable.Priority < current.Priority)
					return;
				
				Debug.Log("Setting to current");
				current = interactable;
				IconPNJ.Instance.SetCurrent(current);
			}
		}
		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				if(current != interactable)
					return;
				
				Debug.Log("Clearing current");
				current = null;
				IconPNJ.Instance.ClearCurrent();
			}
		}
	}
}