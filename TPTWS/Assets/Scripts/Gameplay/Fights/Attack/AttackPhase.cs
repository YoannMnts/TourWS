using TPT.Core.Phases;
using UnityEngine;

namespace TPT.Gameplay.Fights.Attack
{
    public abstract class AttackPhase : IPhase
    {
        private readonly HeroTurnPhase heroTurnPhase;

        public AttackPhase(HeroTurnPhase heroTurnPhase)
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