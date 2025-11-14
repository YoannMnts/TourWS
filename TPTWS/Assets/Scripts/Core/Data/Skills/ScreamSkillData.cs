using UnityEngine;

namespace TPT.Core.Data.Skills
{
    [CreateAssetMenu(fileName = "Scream", menuName = "TPT/Skills/Scream", order = 0)]
    public class ScreamSkillData : SkillData
    {
        [field: SerializeField, Range(0, 10)] 
        public int Duration { get; private set; } = 2;
        
        [field: SerializeField, Range(0, 3)] 
        public int Range { get; private set; } = 2;
    }
}