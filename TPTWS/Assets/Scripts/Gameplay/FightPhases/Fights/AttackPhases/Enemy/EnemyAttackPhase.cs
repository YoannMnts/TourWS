using System.Collections.Generic;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Fights.AttackPhases.Enemy
{
    public class EnemyAttackPhase : AttackPhase
    {
        public EnemyAttackPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
            
        }

        protected override async Awaitable Execute()
        {
            IReadOnlyList<IFightSkill> attacks = Hero.Skills;
            
            int rnd = Random.Range(0, attacks.Count);
            IFightSkill atk = attacks[rnd];
            
            await atk.Perform(Hero, Grid, Hero.Coordinates);
        }
    }
}