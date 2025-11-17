using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.SpawnPoint;
using TPT.Gameplay.Heroes;
using TPT.Gameplay.Players;
using TPT.Gameplay.Players.Interactions;
using TPT.Gameplay.PNJs;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

namespace Debug
{
    public class FightLauncher: MonoBehaviour,IInteractable
    {
        [SerializeField] 
        private FightGrid grid;
        
        [SerializeField]
        private PlayerHero[] playerHeroes;
<<<<<<< HEAD
        [SerializeField] private Transform playerTransform;

        public void Interact()
        {
            PlayerSaveSystem.SavePlayerPosition(playerTransform);
=======
        [SerializeField]
        private GameObject laPorteDeLAGrid;
        [SerializeField] 
        private PlayerMovement playerMovement;
        [SerializeField]
        private NavMeshAgent[] heroFollowScript;

        public void Interact()
        {
            foreach (var followCharacter in heroFollowScript)
            {
                followCharacter.enabled = false;
            }
            //PlayerSaveSystem.SavePlayerPosition(playerTransform);
>>>>>>> origin/Dev
            using (ListPool<IFightHero>.Get(out var list))
            {
                for (int i = 0; i < grid.Enemies.Length; i++)
                {
                    EnemySpawnPoints spawnPoints = grid.Enemies[i];
                    list.Add(spawnPoints.Enemy);
                }

                for (int i = 0; i < grid.PlayerHero.Length; i++)
                {
                    PlayerSpawnPoint spawnPoints = grid.PlayerHero[i];
                    list.Add(spawnPoints.PlayerHero);
                }
                list.Sort();
                list.Reverse();
                FightPhase fightPhase = new FightPhase(list.ToArray(), grid, laPorteDeLAGrid, playerMovement);
                playerMovement.enabled = false;
                fightPhase.Run();
            }
        }
        
    }
    
}