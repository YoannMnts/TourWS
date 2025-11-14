using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Players
{
        [RequireComponent(typeof(CharacterController))]
        public class PlayerMovement : MonoBehaviour
        {
                public float speed = 5f;
                public float rotationSpeed = 10f;
                public float gravity = -9.81f;

                private CharacterController controller;
                private PlayerInput playerInput;
                private Vector3 velocity;
                private bool isGrounded;

                void Start()
                {
                        controller = GetComponent<CharacterController>();
                        playerInput = GetComponent<PlayerInput>();
                        playerInput.ActivateInput();
                }
                void FixedUpdate()
                {
                        // --- Gestion du sol ---
                        isGrounded = controller.isGrounded;
                        if (isGrounded && velocity.y < 0)
                                velocity.y = -2f;

                        // --- Entrées ---
                        string playerMove = "Player/Move";
                        InputAction inputAction = playerInput.actions.FindAction(playerMove);
                        if (inputAction == null)
                        {
                                Debug.Log($"Didn't find action {playerMove}");
                                return;
                        }
                        Vector2 input =  inputAction.ReadValue<Vector2>();
                        
                        float moveX = input.x;
                        float moveZ =input.y;

                        Vector3 direction = new Vector3(moveX, 0f, moveZ).normalized;

                        // --- Rotation du joueur ---
                        if (direction.magnitude >= 0.1f)
                        {
                                // Calcule la direction vers laquelle regarder
                                Quaternion targetRotation = Quaternion.LookRotation(direction);
                                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,
                                        rotationSpeed * Time.deltaTime);

                                // --- Déplacement ---
                                Vector3 move = transform.forward * (speed * Time.deltaTime);
                                controller.Move(move);
                        }

                        // --- Gravité ---
                        velocity.y += gravity * Time.deltaTime;
                        controller.Move(velocity * Time.deltaTime);
                }
        }
}