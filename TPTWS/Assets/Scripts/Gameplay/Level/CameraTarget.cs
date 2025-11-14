using UnityEngine;

namespace TPT.Gameplay.Level
{
    public class CameraTarget : MonoBehaviour
    {
        public Transform player;        // Le joueur à suivre
        public float followSpeed = 5f;  // Vitesse de suivi

        private Vector3 offset;          // Décalage initial entre la caméra et le joueur

        void Start()
        {
            // Calculer l'offset initial pour garder la caméra à la même position relative
            offset = transform.position - player.position;
        }

        void LateUpdate()
        {
            // Nouvelle position souhaitée (seulement en translant la caméra sans changer la rotation)
            Vector3 targetPosition = player.position + offset;

            // Déplacement doux de la caméra vers le joueur
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
