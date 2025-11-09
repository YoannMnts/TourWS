using TPT.Core.Phases;
using UnityEngine;

namespace TPT.Gameplay.Fights.MovementPhase
{
    public class EnemyMovementPhase : MovementPhase
    {
        public EnemyMovementPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
            
        }

        protected override Awaitable Execute()
        {
            Debug.Log($"{heroTurnPhase.hero} want to move");
            return PhaseManager.CompletedPhase;
        }
    }
}