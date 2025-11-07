using UnityEngine;

namespace TPT.Core.Core.HeroData.SkillData
{
        [CreateAssetMenu(fileName = "Skill", menuName = "TPT/skill", order =0)]
    public class SkillData : ScriptableObject
    {
        [field: SerializeField]
                public string Name { get; private set; }
        
                [field: SerializeField, TextArea]
                public string Description { get; private set; }
                
                [field: SerializeField]
                public int Range { get; private set; }
        
                [field: SerializeField]
                public int Power { get; private set; }
        
                [field: SerializeField]
                public GameObject Prefab { get; private set; }
    }
}
