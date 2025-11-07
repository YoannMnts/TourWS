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
            throw new System.NotImplementedException();
        }
    }
}