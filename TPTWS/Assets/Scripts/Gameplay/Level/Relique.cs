using TPT.Core.Data;
using UnityEngine;

namespace TPT.Gameplay.Level
{
    public class Relique : MonoBehaviour
    {
        [SerializeField] private KeyCode interactKey = KeyCode.E;
        private HeroData hero;
        private bool playerInRange = false;
        void Update()
        {
            if (playerInRange && Input.GetKeyDown(interactKey))
            {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }

        private void Strenght()
        {
            
        }
        private void Health()
        {
            
        }
        
    }
}
