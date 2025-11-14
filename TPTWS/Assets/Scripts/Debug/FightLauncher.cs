using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.SpawnPoint;
using TPT.Gameplay.Heroes;
using TPT.Gameplay.Players;
using TPT.Gameplay.Players.Interactions;
using TPT.Gameplay.PNJs;
using UnityEngine;
using UnityEngine.Pool;

namespace Debug
{
    public class FightLauncher: MonoBehaviour,IInteractable
    {
        [SerializeField] 
        private FightGrid grid;
        
        [SerializeField]
        private PlayerHero[] playerHeroes;
        [SerializeField] private Transform playerTransform;

        public void Interact()
        {
            PlayerSaveSystem.SavePlayerPosition(playerTransform);
            using (ListPool<IFightHero>.Get(out var list))
            {
                for (int i = 0; i < grid.Enemies.Length; i++)
                {
                    EnemySpawnPoints spawnPoints = grid.Enemies[i];
                    list.Add(spawnPoints.Enemy);
                }

                for (int i = 0; i < playerHeroes.Length; i++)
                    list.Add(playerHeroes[i]);

                list.Sort();
                list.Reverse();
                FightPhase fightPhase = new FightPhase(list.ToArray(), grid);

                fightPhase.Run();
            }
        }
        
    }
    
}