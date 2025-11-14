using TPT.Gameplay.Players;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TPT.Gameplay
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
                {
                        if (other.CompareTag("Player"))
                        {
                                PlayerController player = other.GetComponent<PlayerController>();
                                if (player != null)
                                {
                                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                                }
                                else
                                {
                                        other.gameObject.SetActive(false);
                                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                                }
                        }
                }
    }
}
