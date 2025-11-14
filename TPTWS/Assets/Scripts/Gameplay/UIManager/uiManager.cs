using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPT.Gameplay.UIManager
{
    public class uiManager : MonoBehaviour
    {
	    [SerializeField] private GameObject pauseInterface;

	    public void Start()
	    {

		    pauseInterface.SetActive(false);
		    Time.timeScale = 1;
	    }
	    public void Pause()
	    {
		    pauseInterface.SetActive(true);
		    Time.timeScale = 0;
	    }
	    
	    public void Resume()
	    {
		    pauseInterface.SetActive(false);
		    Time.timeScale = 1;
	    }

	    public void Home()
	    {
		    SceneManager.LoadScene(0);
	    }
	    public void Quit()
	    {
		    Application.Quit();
	    }
    }
    
}
