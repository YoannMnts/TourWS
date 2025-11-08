using TPT.Gameplay.Fights;

namespace TPT.Gameplay.Heroes
{
    public class EnemyHero : Hero, IFightHero
    {
        public override bool IsPlayerHero => false;
    }
}