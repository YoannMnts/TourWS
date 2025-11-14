using UnityEngine;
using System;
using TPT.Gameplay.Players.Interactions;

namespace TPT.Gameplay.Level
{
    public class Levier : MonoBehaviour, IInteractable
    {
        public event Action OnLevierChange;
        public bool isActive = false;
        public void Interact()
        {
                if (isActive)
                        return;
                
                isActive = !isActive;
                gameObject.transform.localRotation = Quaternion.Euler(isActive ? 45f : 0f, 0f, -45f);
    
                OnLevierChange?.Invoke();
        }
    }
}
