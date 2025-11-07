using UnityEngine;

namespace TPT.Gameplay.Players
{
    public class PlayerController : MonoBehaviour
    {
        public Transform[] GetHeroPosition() => heroSpawnPoints;

        [SerializeField]
        private Transform[] heroSpawnPoints;
        
        private void EnterInFight()
        {
            //FightPhase fightPhase = new FightPhase(this, gridManager);
            //fightPhase.Run();
        }
    }
}