using UnityEngine;

namespace TPT.Core.Data.Skills
{
    [CreateAssetMenu(fileName = "Invisibility", menuName = "TPT/Skills/Invisibility")]
    public class InvisibilityData : SkillData
    {
        [field: SerializeField]
        public int Duration { get; private set; }
    }
}