using UnityEngine;

namespace TPT.Gameplay.PNJ
{
        public class InteractPNJ : MonoBehaviour
        {
                public IconPNJ iconPNJ;
                public ChatBubble chatBubble;
                public bool fighting = false;
                
                public void Interact()
                {
                        Debug.Log("Interact");
                        fighting = true;

                        // Cache l’icône
                        iconPNJ.ClearCurrent();
                        chatBubble.Show();
                }
        }
}