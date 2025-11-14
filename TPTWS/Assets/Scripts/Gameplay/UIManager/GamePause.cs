using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPT.Gameplay.UIManager
{
	public class GamePause : MonoBehaviour
	{
		[SerializeField] private GameObject pauseInterface;

		void Start()
		{
			pauseInterface.SetActive(false);
		}
		[UsedImplicitly]
		public void Load()
		{
			SceneManager.LoadScene(1);
			Resume();
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