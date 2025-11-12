using UnityEngine;

namespace TPT.Gameplay.Level
{
        public class InteractLevier : MonoBehaviour
        {
                [SerializeField] private KeyCode interactKey = KeyCode.E;
                private Levier currentLevier;

                private void Update()
                {
                        if (currentLevier != null && Input.GetKeyDown(interactKey))
                        {
                                currentLevier.Interacting();
                        }
                }

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