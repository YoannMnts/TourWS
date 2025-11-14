using TPT.Gameplay.Level;
using TPT.Gameplay.PNJs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Players.Interactions
{
	public class PlayerInteractions : MonoBehaviour
	{
		private IInteractable current;

		public void OnInteractInput(InputAction.CallbackContext context)
		{
			Debug.Log($"j'interagit avec : {current}");
			if (current != null  && context.performed)
				current.Interact();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				Debug.Log(interactable.transform.name, interactable.transform);
				
				Debug.Log("Setting to current");
				current = interactable;
				IconPNJ.Instance.SetCurrent(current);
			}

			Debug.Log($"trigerred by {other.name}");
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