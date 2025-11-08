using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Players
{
    public class PlayerMovementFight : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement
        [SerializeField] private PlayerInput  playerInput;
        
        private CharacterController controller;
        
        private InputAction moveAction;
    
        void Start()
        {
            moveAction=playerInput.actions.FindActionMap("Fight").FindAction("Movement");
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            
        }

        void FixedUpdate()
        {
            
        }
    }
}