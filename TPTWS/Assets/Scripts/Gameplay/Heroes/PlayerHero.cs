using System;
using TPT.Gameplay.FightPhases;
using UnityEngine;

namespace TPT.Gameplay.Heroes
{
    public class PlayerHero: Hero, IFightHero
    {
        public override bool IsPlayerHero => true;

        protected override void Die()
        {
            Debug.Log($"{HeroData.name} is dead");
        }
    }
}