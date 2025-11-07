using TPT.Core.Phases;
using TPT.Gameplay.Grids;
using UnityEngine;

namespace TPT.Gameplay.Fights.MovementPhase
{
    public abstract class MovementPhase : IPhase
    {
        protected IFightHero Hero => heroTurnPhase.hero;
        
        protected FightGrid Grid => heroTurnPhase.fightPhase.fightGrid;
        
        protected readonly HeroTurnPhase heroTurnPhase;

        public MovementPhase(HeroTurnPhase heroTurnPhase)
        {
            this.heroTurnPhase = heroTurnPhase;
        }

        Awaitable IPhase.Begin()
        {
            return null;
        }

        async Awaitable IPhase.Execute()
        {
            await Execute();
        }

        Awaitable IPhase.End()
        {
            return null;
        }
        
        protected abstract Awaitable Execute();
    }
}