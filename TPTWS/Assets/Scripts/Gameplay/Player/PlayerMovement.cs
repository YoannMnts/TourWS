using TPT.Gameplay.PNJ;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement
        [SerializeField] private PlayerInput  playerInput;
        
        private CharacterController controller;
        
        private Vector2 inputDirection;
        private Vector3 targetVelocity;
        private Vector3 currentVelocity;
        private InputAction moveAction;
    
        void Start()
        {
            moveAction=playerInput.actions.FindActionMap("Exploration").FindAction("Movement");
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            inputDirection = moveAction.ReadValue<Vector2>();
            targetVelocity = new Vector3(inputDirection.x, 0f, inputDirection.y)* moveSpeed;
        }

        void FixedUpdate()
        {
            controller.Move(targetVelocity * Time.deltaTime);
        }

    }
}
