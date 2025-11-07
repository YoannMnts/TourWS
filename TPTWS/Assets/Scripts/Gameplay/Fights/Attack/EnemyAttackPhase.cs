using UnityEditor.VersionControl;
using UnityEngine;

namespace TPT.Gameplay.Fights.Attack
{
    public class EnemyAttackPhase : AttackPhase
    {
        public EnemyAttackPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
            
        }

        protected override async Awaitable Execute()
        {
        }
    }
}