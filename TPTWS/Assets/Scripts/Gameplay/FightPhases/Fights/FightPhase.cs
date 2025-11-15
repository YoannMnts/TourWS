using DG.Tweening;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TPT.Gameplay.FightPhases
{
    public class FightPhase : IPhase
    {
        public readonly FightGrid grid;
        public readonly IFightHero[] heroes;
        public readonly Transform playerLastPos;
        public readonly GameObject laPorte;
        public readonly PlayerMovement playerMovement;

        public FightPhase(IFightHero[] heroes, FightGrid grid, Transform playerLastPos, GameObject laPorte, PlayerMovement playerMovement)
        {
            this.heroes = heroes;
            this.grid = grid;
            this.playerLastPos = playerLastPos;
            this.laPorte = laPorte;
            this.playerMovement = playerMovement;
        }



        async Awaitable IPhase.Begin()
        {
            
            grid.GenerateCells();
            for (int i = 0; i < heroes.Length; i++)
            {
                Debug.Log($"c'est la grid : {grid}");
                FightCell cell = grid.GetCellSpawn(heroes[i]);
                IFightHero fightHero = heroes[i];
                await fightHero.MoveTo(cell.Coordinates);
                
                await grid.AddMember(fightHero);
                
            }
        }

        async Awaitable IPhase.Execute()
        {
            int currentIndex = 0;

            while (true)
            {
                for (int i = 0; i < heroes.Length; i++)
                {
                    if (IsFightFinished(out bool isPlayerTeamDead))
                    {
                        if (isPlayerTeamDead)
                            SceneManager.LoadScene(0);
                        laPorte.SetActive(false);
                        playerMovement.enabled = true;
                        return;
                    }

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
        }
        
        Awaitable IPhase.End()
        {
            for (int i = 0; i < heroes.Length; i++)
            {
                var isPlayerHero = heroes[i].IsPlayerHero;
                var pos = isPlayerHero && playerLastPos.position != null ? playerLastPos.position : heroes[i].transform.position;
                heroes[i].transform.DOMove(pos, 1f);
                grid.RemoveMember(heroes[i]);
            }
            
            grid.DestroyCells();
            //foreach (IFightHero fightHero in heroes)
            //    fightHero.MoveTo()
            return PhaseManager.CompletedPhase;
        }
        
        private bool IsFightFinished(out bool isPlayerTeamIsDead)
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
            isPlayerTeamIsDead = playerTeamIsDead;
            return playerTeamIsDead || enemiesTeamIsDead;
            
        }
    }
}
