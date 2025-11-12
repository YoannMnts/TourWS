using System;
using TPT.Gameplay.Fights;

namespace TPT.Gameplay.Heroes
{
    public class PlayerHero: Hero, IFightHero
    {
        public override bool IsPlayerHero => true;
    }
}