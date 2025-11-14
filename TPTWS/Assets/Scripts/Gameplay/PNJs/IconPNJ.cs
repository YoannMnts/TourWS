using TPT.Gameplay.Players.Interactions;
using UnityEngine;
using UnityEngine.UI;

namespace TPT.Gameplay.PNJs
{
    public class IconPNJ : MonoBehaviour
    {
        public static IconPNJ Instance;
        private IInteractable currentInteractable;
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
            if (currentInteractable != null)
            {
                Vector3 worldPos = currentInteractable.transform.position + Vector3.right* IconR + Vector3.up * 1; // plus haut que la tête
                Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);
                
                if (screenPos.z > 0)
                {
                    leftClickIcon.rectTransform.position = screenPos;
                    //chatBubble.rectTransform.position = screenPos;
                    leftClickIcon.enabled = true; return;
                    
                }
            }
        }
        public void SetCurrent(IInteractable npc)
        {
            currentInteractable = npc;
        }
        public void ClearCurrent()  
        {
            leftClickIcon.enabled = false;
            currentInteractable = null;

            
        }
    }
}
