
/*
 using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.Player
{
        public class ATTInteraction : MonoBehaviour
        {
                private PlayerInput input;
                private bool canAct = false;

                void Awake()
                {
                        input = new PlayerInput();
                }

                void OnEnable()
                {
                        input.Attaque.Enable();

                        input.Attaque.AttaqueNormal.performed += OnAttaqueNormal;
                        input.Attaque.AttaqueSpecial.performed += OnAttaqueSpecial;
                }

                void OnDisable()
                {
                        input.Attaque.AttaqueNormal.performed -= OnAttaqueNormal;
                        input.Attaque.AttaqueSpecial.performed -= OnAttaqueSpecial;

                        input.Attaque.Disable();
                }

                public void SetCanAct(bool value)
                {
                        canAct = value;
                }

                private void OnAttaqueNormal(InputAction.CallbackContext ctx)
                {
                        if (!canAct) return;

                        TurnManager.TurnManager.Instance.PlayerAttack(false);
                        canAct = false;
                }

                private void OnAttaqueSpecial(InputAction.CallbackContext ctx)
                {
                        if (!canAct) return;

                        TurnManager.TurnManager.Instance.PlayerAttack(true);
                        canAct = false;
                }
        }
}
*/