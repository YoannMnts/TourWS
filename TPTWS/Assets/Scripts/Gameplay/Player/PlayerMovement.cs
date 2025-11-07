using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
        [RequireComponent(typeof(CharacterController))]
        public class PlayerMovement : MonoBehaviour
        {
                public float speed = 5f; // Vitesse de déplacement
                public float gravity = -9.81f; // Gravité

                private CharacterController controller;
                private Vector3 velocity;
                private bool isGrounded;

                void Start()
                {
                        controller = GetComponent<CharacterController>();
                }

                void Update()
                {
                        // Vérifie si le joueur est au sol
                        isGrounded = controller.isGrounded;
                        if (isGrounded && velocity.y < 0)
                        {
                                velocity.y = -2f; // petite valeur pour rester collé au sol
                        }
                        
                        float moveX = Input.GetAxis("Horizontal"); // A/D ou flèches
                        float moveZ = Input.GetAxis("Vertical"); // W/S ou flèches
                        
                        Vector3 move = transform.right * moveX + transform.forward * moveZ;
                        controller.Move(move * speed * Time.deltaTime);
                        
                        velocity.y += gravity * Time.deltaTime;
                        controller.Move(velocity * Time.deltaTime);
                }
        }
}