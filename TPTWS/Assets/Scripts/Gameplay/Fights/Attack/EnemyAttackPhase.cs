using System.Collections.Generic;
using TPT.Core.Phases;
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
            IReadOnlyList<IFightSkill> attacks = Hero.Skills;
            
            int rnd = Random.Range(0, attacks.Count);
            IFightSkill atk = attacks[rnd];
            
            await atk.Perform(Hero, Grid, Hero.Coordinates);
        }
    }
}