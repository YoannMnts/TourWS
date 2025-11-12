using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
        [RequireComponent(typeof(CharacterController))]
        public class PlayerMovement : MonoBehaviour
        {
                public float speed = 5f; // Vitesse de déplacement
                public float rotationSpeed = 2f; // Vitesse de déplacement
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
                        Vector3 direction = Vector3.zero;

                        if (Input.GetKey(KeyCode.Z))
                                direction = Vector3.forward;
                        else if (Input.GetKey(KeyCode.S))
                                direction = Vector3.back;
                        else if (Input.GetKey(KeyCode.Q))
                                direction = Vector3.left;
                        else if (Input.GetKey(KeyCode.D))
                                direction = Vector3.right;
                        
                        // Si une touche directionnelle est pressée
                        if (direction != Vector3.zero)
                        {
                                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation,
                                        rotationSpeed * Time.deltaTime);
                        }
                        isGrounded = controller.isGrounded;
                        if (isGrounded && velocity.y < 0)
                        {
                                velocity.y = -2f; 
                        }
                        float moveX = Input.GetAxis("Horizontal");
                        float moveZ = Input.GetAxis("Vertical");   

                        Vector3 move = transform.right * moveX + transform.forward * moveZ;
                        controller.Move(move * speed * Time.deltaTime);

                        velocity.y += gravity * Time.deltaTime;
                        controller.Move(velocity * Time.deltaTime);
                }
        }
}