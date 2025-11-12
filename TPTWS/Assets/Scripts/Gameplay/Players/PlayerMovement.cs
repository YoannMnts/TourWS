using UnityEngine;

namespace TPT.Gameplay.Player
{
        [RequireComponent(typeof(CharacterController))]

        public class PlayerMovement : MonoBehaviour
        {
                public float speed = 5f;
                public float rotationSpeed = 10f;
                public float gravity = -9.81f;

                private CharacterController controller;
                private Vector3 velocity;
                private bool isGrounded;

                void Start()
                {
                        controller = GetComponent<CharacterController>();
                }

                void Update()
                {
                        // --- Gestion du sol ---
                        isGrounded = controller.isGrounded;
                        if (isGrounded && velocity.y < 0)
                                velocity.y = -2f;

                        // --- Entrées ---
                        float moveX = Input.GetAxisRaw("Horizontal");
                        float moveZ = Input.GetAxisRaw("Vertical");

                        Vector3 direction = new Vector3(moveX, 0f, moveZ).normalized;

                        // --- Rotation du joueur ---
                        if (direction.magnitude >= 0.1f)
                        {
                                // Calcule la direction vers laquelle regarder
                                Quaternion targetRotation = Quaternion.LookRotation(direction);
                                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,
                                        rotationSpeed * Time.deltaTime);

                                // --- Déplacement ---
                                Vector3 move = transform.forward * speed * Time.deltaTime;
                                controller.Move(move);
                        }

                        // --- Gravité ---
                        velocity.y += gravity * Time.deltaTime;
                        controller.Move(velocity * Time.deltaTime);
                }
        }
}