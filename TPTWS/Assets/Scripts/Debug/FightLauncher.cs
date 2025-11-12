using System;
using NUnit.Framework.Internal;
using TPT.Core.Phases;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Heroes;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

namespace Debug
{
    public class FightLauncher: MonoBehaviour
    {
        [SerializeField] 
        private FightGrid grid;
        
        [SerializeField]
        private PlayerHero[] playerHeroes;

        private void Start()
        {
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
                FightPhase fightPhase = new FightPhase(list.ToArray(), grid);

                fightPhase.Run();
            }
        }
    }
}