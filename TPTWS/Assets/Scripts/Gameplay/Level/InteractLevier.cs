using UnityEngine;

namespace TPT.Gameplay.Level
{
        public class InteractLevier : MonoBehaviour
        {
                private Levier _currentLevier;
                
                private void OnTriggerEnter(Collider other)
                {
                        Levier levier = other.GetComponent<Levier>();
                        if (levier != null)
                                _currentLevier = levier;
                }

                private void OnTriggerExit(Collider other)
                {
                        Levier levier = other.GetComponent<Levier>();
                        if (levier != null && levier == _currentLevier)
                                _currentLevier = null;
                }
        }
}