using TPT.Core.Phases;
using TPT.Gameplay.Grids;
using UnityEngine;

namespace TPT.Gameplay.Fights
{
    public class FightPhase : IPhase
    {
        public readonly FightGrid fightGrid;
        public readonly IFightHero[] heroes;

        public FightPhase(IFightHero[] heroes, FightGrid fightGrid)
        {
            this.heroes = heroes;
            this.fightGrid = fightGrid;
        }


        private void StartFight(int gridIndex)
        {
            
        }

        Awaitable IPhase.Begin()
        {
            //GridManager.GenerateGrids(0);
            //GridManager.InitializeHeroPositionOnCell(Player.GetHeroPosition());
            return null;
        }

        async Awaitable IPhase.Execute()
        {
            int currentIndex = 0;
            for (int i = 0; i < heroes.Length; i++)
            {
                if (IsFightFinished())
                    break;
                
                IFightHero hero = heroes[i];
                if (!hero.IsAlive)
                {
                    currentIndex++;
                    if (currentIndex >= heroes.Length)
                        currentIndex = 0;
                    
                    continue;
                }
                
                HeroTurnPhase turnPhase = new HeroTurnPhase(hero, this);
                await turnPhase.RunAsync();
                
                currentIndex++;
                if (currentIndex >= heroes.Length)
                    currentIndex = 0;
            }
        }

        private bool IsFightFinished()
        {
            bool playerTeamIsDead = true;
            bool enemiesTeamIsDead = true;
            foreach (var hero in heroes)
            {
                if (hero.IsAlive && hero.IsPlayerHero)
                    playerTeamIsDead = false;

                if (hero.IsAlive && !hero.IsPlayerHero)
                    enemiesTeamIsDead = false;
                
            }
            return playerTeamIsDead || enemiesTeamIsDead;
        }

        Awaitable IPhase.End()
        {
            return null;
        }
    }
}