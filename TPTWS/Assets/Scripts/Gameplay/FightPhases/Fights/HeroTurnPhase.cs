using System.Collections.Generic;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Fights.AttackPhases;
using TPT.Gameplay.FightPhases.Fights.AttackPhases.Enemy;
using TPT.Gameplay.FightPhases.Fights.AttackPhases.Player;
using TPT.Gameplay.FightPhases.Fights.MovementPhase.Player;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Fights.MovementPhase;
using TPT.Gameplay.Grids;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Gameplay.FightPhases.Fights
{
    public class HeroTurnPhase : IPhase
    {
        public readonly IFightHero hero;
        public readonly FightPhase fightPhase;
        
        public readonly List<CellCoordinate> heroesCells = new List<CellCoordinate>();

        public HeroTurnPhase(IFightHero hero, FightPhase fightPhase)
        {
            this.hero = hero;
            this.fightPhase = fightPhase;
        }
        
        async Awaitable IPhase.Begin()
        {
            await hero.OnTurnBegin();
            foreach (var fightPhaseHero in fightPhase.heroes)
            {
                var heroCellCoordinate = fightPhaseHero.Coordinates;
                heroesCells.Add(heroCellCoordinate);
            }
        }

        async Awaitable IPhase.Execute()
        {
            if (hero.IsPlayerHero)
            {
                var playerMovementPhase = new PlayerMovementPhase(this);
                await playerMovementPhase.RunAsync();
            }
            else
            {
                var enemyMovementPhase = new EnemyMovementPhase(this);
                await enemyMovementPhase.RunAsync();
            }
            
            if (hero.IsPlayerHero)
            {
                var playerAttackPhase = new PlayerAttackPhase(this);
                await playerAttackPhase.RunAsync();
            }
            else
            {
                var enemyAttackPhase = new EnemyAttackPhase(this);
                await enemyAttackPhase.RunAsync();
            }
        }

        async Awaitable IPhase.End()
        {
            await hero.OnTurnEnd();
        }
    }
}