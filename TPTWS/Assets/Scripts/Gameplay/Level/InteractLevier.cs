using TPT.Gameplay.Players.Interactions;
using UnityEngine;

namespace TPT.Gameplay.Level
{
        public class InteractLevier : MonoBehaviour, IInteractable
        {
                [SerializeField]
                private KeyCode interactKey = KeyCode.E;
                public int Priority => 3;
                
                
                public void Interact()
                {
                        currentLevier.Interacting();
                }

                private Levier currentLevier;
                
                private void OnTriggerEnter(Collider other)
                {
                        Levier levier = other.GetComponent<Levier>();
                        if (levier != null)
                                currentLevier = levier;
                }

                private void OnTriggerExit(Collider other)
                {
                        Levier levier = other.GetComponent<Levier>();
                        if (levier != null && levier == currentLevier)
                                currentLevier = null;
                }
        }
}