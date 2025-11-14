using TPT.Gameplay.Players;
using TPT.Gameplay.Players.Interactions;
using UnityEngine;

namespace TPT.Gameplay.PNJs
{
    public class InteractEnnemy : MonoBehaviour, IInteractable
        {
                [SerializeField] private string ChatText;
                [SerializeField] private string ChatText2;
                
                [SerializeField] private IconPNJ iconPNJ;
                [SerializeField] private ChatBubble chatBubble;
                [SerializeField] private PlayerMovement playerMovement;
                public bool combat = false;
                
                private int TextCount = 0;

                private void Start()
                {
                        combat=false;
                        TextCount=0;
                }
                
                public void Interact()
                {
                        switch (TextCount)
                        {
                                case 0:
                                        playerMovement.enabled = false;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Show(ChatText);
                                        TextCount++;
                                        break;
                                case 1:
                                        Debug.Log("Interact");
                                        // Cache l’icône
                                        playerMovement.enabled = false;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Show(ChatText2);
                                
                                        TextCount++;
                                        break;
                                case 3:
                                        playerMovement.enabled = true;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Hide();
                                        TextCount=0;
                                        combat = true;
                                        break;
                        }
                }
        }
}
