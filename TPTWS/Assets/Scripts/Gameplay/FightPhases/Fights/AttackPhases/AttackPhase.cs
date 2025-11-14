using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.AttackPhases
{
    public abstract class AttackPhase : IPhase
    {
        protected IFightHero Hero => heroTurnPhase.hero;
        protected FightGrid Grid => heroTurnPhase.fightPhase.grid;

        public readonly HeroTurnPhase heroTurnPhase;

        public AttackPhase(HeroTurnPhase heroTurnPhase)
        {
            this.heroTurnPhase = heroTurnPhase;
        }

        Awaitable IPhase.Begin()
        {
            return PhaseManager.CompletedPhase;
        }

        async Awaitable IPhase.Execute()
        {
            await Execute();
        }

        Awaitable IPhase.End()
        {
            return PhaseManager.CompletedPhase;
        }

        protected abstract Awaitable Execute();
    }
}