using UnityEngine;

namespace TPT.Core.Data.Skills
{    
    [CreateAssetMenu(fileName = "Heal All", menuName = "TPT/Skills/HealAll", order = 0)]
    public class HealAllSkillData : SkillData
    {
        [field: SerializeField]
        public int Heal { get; private set; }
    }
}