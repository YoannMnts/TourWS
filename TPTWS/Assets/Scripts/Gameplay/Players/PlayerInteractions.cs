using TPT.Gameplay.PNJ;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
        public class PlayerInteractions : MonoBehaviour
        {
                [SerializeField] 
                private float interactRange = 2f;
                
                public void OnInteractInput(InputAction.CallbackContext context)
                {
                        Collider[] collidersArrays = Physics.OverlapSphere(transform.position, interactRange);
                        foreach (Collider collider in collidersArrays)
                        {
                                if (collider.TryGetComponent(out InteractPNJ interactPNJ))
                                {
                                        interactPNJ.Interact();
                                }
                        }   
                }
        }
}