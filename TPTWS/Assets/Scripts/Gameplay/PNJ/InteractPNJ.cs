using UnityEngine;
using TPT.Gameplay.Player;
namespace TPT.Gameplay.PNJ
{
        public class InteractPNJ : MonoBehaviour
        {
                [SerializeField] private string ChatText;
                public IconPNJ iconPNJ;
                public ChatBubble chatBubble;
                public PlayerMovement playerMovement;
                public bool fighting = false;
                private int TextCount = 0;

                private void Start()
                {
                }
                
                public void Interact()
                {
                        if (TextCount==0)
                        {
                                Debug.Log("Interact");
                                fighting = true;
                                // Cache l’icône
                                iconPNJ.ClearCurrent();
                                chatBubble.Show(ChatText);
                                TextCount++;
                        }
                        else
                        {
                                chatBubble.Hide();
                                TextCount = 0;
                        }
                }
        }
}