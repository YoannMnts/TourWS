using UnityEngine;
using System;

namespace TPT.Gameplay.Level
{
    public class Levier : MonoBehaviour
    {
        public event Action OnLevierChange;
        public bool isActive = false;

        void Start()
        {
	        isActive=false;
        }
        public void Interacting()
        {
                if (isActive)
                        return;
    
                isActive = !isActive;
                transform.localRotation = Quaternion.Euler(isActive ? 45f : 0f, 0f, -45f);
    
                OnLevierChange?.Invoke();
        }
    }
}
