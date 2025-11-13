using UnityEngine;

namespace TPT.Gameplay.Level
{
    public class DoorMove : MonoBehaviour
    {
            [SerializeField] private float startHeight = 0f;    
            [SerializeField] private float loweredHeight = -5f;  
            [SerializeField] private float moveSpeed = 2f;     
        
            private float targetHeight;
        
            private void Start()
            {
                targetHeight = startHeight;
                Vector3 pos = transform.position;
                pos.y = startHeight;
                transform.position = pos;
            }
            private void Update()
            {
                Vector3 pos = transform.position;
                pos.y = Mathf.Lerp(pos.y, targetHeight, Time.deltaTime * moveSpeed);
                transform.position = pos;
            }
            public void SetWaterLevel(float normalizedValue)
            {
                targetHeight = Mathf.Lerp(startHeight, loweredHeight, normalizedValue);
            }
    }
}
