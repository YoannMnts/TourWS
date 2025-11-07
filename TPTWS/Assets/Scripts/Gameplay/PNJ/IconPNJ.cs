using UnityEngine;
using UnityEngine.UI;

namespace TPT.Gameplay.PNJ
{
    public class IconPNJ : MonoBehaviour
    {
        public static IconPNJ Instance;
        private PNJ currentNPC;
        public ChatBubble chatBubble;
        [SerializeField] private float IconR = 1f;
    
        [Header("Image UI de l'icône")]
        public Image leftClickIcon;
    
        [Header("Caméra principale")]
        public Camera mainCamera;
        Collider other;
        
       
        void Awake()
        {
            Instance = this;
            if (mainCamera == null)
                mainCamera = Camera.main;
            if (leftClickIcon == null)
                Debug.LogError("LeftClickIcon UI non assignée dans l'Inspector !");
            leftClickIcon.enabled = true;
            
        }
        void Update()
        {
            if (currentNPC != null)
            {
                Vector3 worldPos = currentNPC.transform.position + Vector3.right* IconR + Vector3.up * 1; // plus haut que la tête
                Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);
                
                if (screenPos.z > 0)
                {
                    leftClickIcon.rectTransform.position = screenPos;
                    //chatBubble.rectTransform.position = screenPos;
                    leftClickIcon.enabled = true; return;
                }
            }
        }
        public void SetCurrentNPC(PNJ npc)
        {
            currentNPC = npc;
        }
        public void ClearCurrent()  
        {
            leftClickIcon.enabled = false;
            currentNPC = null;
        }
    }
}
