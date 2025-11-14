using UnityEngine;

namespace TPT.Core.Data.Skills
{
    [CreateAssetMenu(fileName = "Strike", menuName = "TPT/Skills/Strike", order = 0)]
    public class StrikeSkillData : SkillData
    {
        [field: SerializeField]
        public int Damage { get; private set; }
        [field: SerializeField]
        public int Range { get; private set; }
    }
}