using TPT.Gameplay.Players;
using TPT.Gameplay.Players.Interactions;
using UnityEngine;

namespace TPT.Gameplay.PNJs
{
        public class InteractPNJ : MonoBehaviour, IInteractable
        {
                [SerializeField] private string ChatText;
                [SerializeField] private string ChatText2;
                [SerializeField] private string ChatText3;
                
                [SerializeField] private IconPNJ iconPNJ;
                [SerializeField] private ChatBubble chatBubble;
                [SerializeField] private PlayerMovement playerMovement;
                public bool fighting = false;
                private int TextCount = 0;

                [SerializeField] 
                private int priority = 1;
        
                public int Priority => priority;

                private void Start()
                {
                        playerMovement.enabled = false;
                        iconPNJ.ClearCurrent();
                        chatBubble.Show(ChatText);
                                
                        TextCount++;
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
                                        fighting = true;
                                        // Cache l’icône
                                        playerMovement.enabled = false;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Show(ChatText2);
                                
                                        TextCount++;
                                        break;
                                case 2:
                                        playerMovement.enabled = false;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Show(ChatText3);
                                
                                        TextCount++;
                                        break;
                                case 3:
                                        playerMovement.enabled = true;
                                        iconPNJ.ClearCurrent();
                                        chatBubble.Hide();
                                
                                        TextCount=0;
                                        break;
                        }
                }
        }
}