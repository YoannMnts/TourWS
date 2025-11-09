using TPT.Core.Phases;
using TPT.Gameplay.Fights.Attack;
using TPT.Gameplay.Fights.MovementPhase;
using UnityEngine;

namespace TPT.Gameplay.Fights
{
    public class HeroTurnPhase : IPhase
    {
        public readonly IFightHero hero;
        public readonly FightPhase fightPhase;

        public HeroTurnPhase(IFightHero hero, FightPhase fightPhase)
        {
            this.hero = hero;
            this.fightPhase = fightPhase;
        }
        
        async Awaitable IPhase.Begin()
        {
            await hero.OnTurnBegin();
        }

        async Awaitable IPhase.Execute()
        {
            MovementPhase.MovementPhase movementPhase = hero.IsPlayerHero ? 
                new PlayerMovementPhase(this) :
                new EnemyMovementPhase(this);
            
            await movementPhase.RunAsync();
            
            AttackPhase attackPhase = hero.IsPlayerHero ? 
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