using TPT.Gameplay.FightPhases;
using UnityEngine;

namespace TPT.Gameplay.Heroes
{
    public class EnemyHero : Hero, IFightHero
    {
        public override bool IsPlayerHero => false;
        protected override void Die()
        {
            this.gameObject.GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);
        }
    }
}