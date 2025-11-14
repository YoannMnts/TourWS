using UnityEngine;

namespace TPT.Core.Data.Skills
{
    [CreateAssetMenu(fileName = "Shoot Arrow", menuName = "TPT/Skills/ShootArrow", order = 0)]
    public class ShootArrowData : SkillData
    {
        [field: SerializeField]
        public int Damage { get; private set; }
        [field: SerializeField]
        public int Range { get; private set; }
    }
}