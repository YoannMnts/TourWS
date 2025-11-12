using UnityEngine;

namespace TPT.Gameplay.Level
{
    public class DoorMove : MonoBehaviour
    {
            [SerializeField] private float startHeight = 0f;     // Hauteur de départ de l’eau
            [SerializeField] private float loweredHeight = -5f;  // Hauteur quand tout est activé
            [SerializeField] private float moveSpeed = 2f;       // Vitesse du mouvement de l’eau
        
            private float targetHeight;
        
            private void Start()
            {
                targetHeight = startHeight;
                Vector3 pos = transform.position;
                pos.y = startHeight;
                transform.position = pos;
            }
            private void Update()
            {
                // Déplacement fluide vers la hauteur cible
                Vector3 pos = transform.position;
                pos.y = Mathf.Lerp(pos.y, targetHeight, Time.deltaTime * moveSpeed);
                transform.position = pos;
            }
            public void SetWaterLevel(float normalizedValue)
            {
                targetHeight = Mathf.Lerp(startHeight, loweredHeight, normalizedValue);
            }
    }
}
