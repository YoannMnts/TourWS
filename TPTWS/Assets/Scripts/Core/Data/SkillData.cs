using UnityEngine;

namespace TPT.Core.Data
{
    public abstract class SkillData : ScriptableObject
    {
        [field: SerializeField] 
        public string Name { get; private set; }

        [field: SerializeField, TextArea] 
        public string Description { get; private set; }
    }
}
