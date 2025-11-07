using UnityEngine;

namespace TPT.Gameplay.PNJ
{
        public class InteractPNJ : MonoBehaviour
        {
                public IconPNJ iconPNJ;
                public ChatBubble chatBubble;
                
                public void Interact()
                {
                        Debug.Log("Interact");

                        // Cache l’icône
                        iconPNJ.ClearCurrent();
                        chatBubble.Show();
                }
        }
}