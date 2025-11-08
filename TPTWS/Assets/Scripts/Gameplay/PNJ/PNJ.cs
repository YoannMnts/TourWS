using UnityEngine;

namespace TPT.Gameplay.PNJ
{
    public class PNJ : MonoBehaviour
    {
        [SerializeField] private float distanceToInteract = 3f; 
        private Transform player; 
        private InteractPNJ interact;
        private bool isInRange = false;
        void Start()
        {
            interact=GetComponent<InteractPNJ>();
            isInRange = false;
            IconPNJ.Instance.ClearCurrent();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        void Update()
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance < distanceToInteract)
            {
                if (!isInRange)
                {
                    Debug.Log("apparait");
                    isInRange = true;
                    IconPNJ.Instance.SetCurrentNPC(this);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interact.Interact();
                    IconPNJ .Instance.ClearCurrent();
                }
            }
            else
            {
                if (isInRange)
                {
                    isInRange = false;
                    Debug.Log("diparait");
                    IconPNJ.Instance.ClearCurrent();
                    return;
                }
            }
        }
    }
}
