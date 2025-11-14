using UnityEngine;

namespace TPT.Gameplay.Players
{
	public static class PlayerSaveSystem
	{
		public static void SavePlayerPosition(Transform player)
		{
			PlayerPrefs.SetFloat("PlayerPosX", player.position.x);
			PlayerPrefs.SetFloat("PlayerPosY", player.position.y);
			PlayerPrefs.SetFloat("PlayerPosZ", player.position.z);

			PlayerPrefs.Save();
		}

		public static void LoadPlayerPosition(Transform player)
		{
			if (!PlayerPrefs.HasKey("PlayerPosX"))
				return;

			float x = PlayerPrefs.GetFloat("PlayerPosX");
			float y = PlayerPrefs.GetFloat("PlayerPosY");
			float z = PlayerPrefs.GetFloat("PlayerPosZ");

			player.position = new Vector3(x, y, z);
		}
	}
}