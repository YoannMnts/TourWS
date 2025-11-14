using UnityEngine;

namespace TPT.Core.Data.Skills
{
    [CreateAssetMenu(fileName = "Shoot Arrow", menuName = "TPT/Skills/ShootArrow", order = 0)]
    public class ShootArrowSkillData : SkillData
    {
        [field: SerializeField]
        public int Damage { get; private set; }
        [field: SerializeField, Range(0,3)]
        public int Range { get; private set; }
    }
}