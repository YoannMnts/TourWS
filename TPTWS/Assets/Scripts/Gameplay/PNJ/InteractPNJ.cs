using UnityEngine;
using TPT.Gameplay.Player;
namespace TPT.Gameplay.PNJ
{
        public class InteractPNJ : MonoBehaviour
        {
                [SerializeField] private string ChatText;
                [SerializeField] private string ChatText2;
                [SerializeField] private string ChatText3;
                [SerializeField] private IconPNJ iconPNJ;
                [SerializeField] private ChatBubble chatBubble;
                [SerializeField] private PlayerMovement playerMovement;
                public bool fighting = false;
                private int TextCount = 0;

                private void Start()
                {
                        playerMovement.enabled = false;
                        iconPNJ.ClearCurrent();
                        chatBubble.Show(ChatText);
                                
                        TextCount++;
                }
                
                public void Interact()
                {
                        if (TextCount == 0)
                        {
                                playerMovement.enabled = false;
                                iconPNJ.ClearCurrent();
                                chatBubble.Show(ChatText);
                                
                                TextCount++;
                        }
                        else if (TextCount==1)
                        {
                                Debug.Log("Interact");
                                fighting = true;
                                // Cache l’icône
                                playerMovement.enabled = false;
                                iconPNJ.ClearCurrent();
                                chatBubble.Show(ChatText2);
                                
                                TextCount++;
                        }
                        else if(TextCount==2)
                        {
                                playerMovement.enabled = false;
                                iconPNJ.ClearCurrent();
                                chatBubble.Show(ChatText3);
                                
                                TextCount++;
                        }
                        else if(TextCount==3)
                        {
                                playerMovement.enabled = true;
                                iconPNJ.ClearCurrent();
                                chatBubble.Hide();
                                
                                TextCount=0;
                        }
                }
        }
}