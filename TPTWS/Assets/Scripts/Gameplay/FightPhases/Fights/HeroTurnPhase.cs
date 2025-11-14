using System.Collections.Generic;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.AttackPhases.Enemy;
using TPT.Gameplay.FightPhases.AttackPhases.Player;
using TPT.Gameplay.FightPhases.MovementPhases.Enemy;
using TPT.Gameplay.FightPhases.MovementPhases.Player;
using TPT.Gameplay.Grids;
using UnityEngine;

namespace TPT.Gameplay.FightPhases
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