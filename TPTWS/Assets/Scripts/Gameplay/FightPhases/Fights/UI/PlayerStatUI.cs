using TMPro;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.UI
{
    public class PlayerStatUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text statAmount;
        
        public void Initialize(IFightHero hero, int index)
        {
            switch (index)
            {
                case 0: statAmount.text = $"{hero.CurrentHealth}/{hero.HeroData.MaxHealth}";
                    break;
                case 1: statAmount.text = $"{hero.CurrentStrength}/{hero.HeroData.Strength}";
                    break;
                case 2: statAmount.text = $"{hero.HeroData.MovementRange}";
                    break;
            }
            
        }
    }
}