using UnityEngine;

namespace TPT.Core.Core.Data.Heroes
{
    [CreateAssetMenu(fileName = "new HeroData", menuName = "TPT/Hero")]
    public class HeroData : ScriptableObject
    {
        public int maxHealth;
        public int maxAttack;
        public int maxMovementPoints;
        public int speed;
    }
}