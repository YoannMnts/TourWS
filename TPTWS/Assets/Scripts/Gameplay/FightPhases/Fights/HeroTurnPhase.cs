using System.Collections.Generic;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Fights.AttackPhase.Player;
using TPT.Gameplay.FightPhases.Fights.MovementPhase.Player;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Fights.Attack;
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
            Gameplay.Fights.MovementPhase.MovementPhase movementPhase = hero.IsPlayerHero ? 
                new PlayerMovementPhase(this) :
                new EnemyMovementPhase(this);
            
            await movementPhase.RunAsync();
            
            AttackPhase.AttackPhase attackPhase = hero.IsPlayerHero ? 
                new PlayerAttackPhase(this) :
                new EnemyAttackPhase(this);
            
            await attackPhase.RunAsync();
        }

        async Awaitable IPhase.End()
        {
            await hero.OnTurnEnd();
        }
    }
}