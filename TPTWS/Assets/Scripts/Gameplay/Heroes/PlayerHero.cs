using System;
using TPT.Gameplay.FightPhases;

namespace TPT.Gameplay.Heroes
{
    public class PlayerHero: Hero, IFightHero
    {
        public override bool IsPlayerHero => true;
    }
}