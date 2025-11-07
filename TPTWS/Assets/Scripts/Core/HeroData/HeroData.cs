using UnityEngine;

namespace TPT.Core.Core.HeroData
{
    [CreateAssetMenu(fileName = "Personnage", menuName = "TPT/Hero", order = 1)]
    public class HeroData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField, TextArea]
        public string Description { get; private set; }

        [field: SerializeField]
        public int MaxHealth { get; private set; }
        
        [field: SerializeField]
        public int Speed { get; private set; }

        [field: SerializeField]
        public int Strength { get; private set; }

        [field: SerializeField]
        public GameObject Prefab { get; private set; }
    }
}
