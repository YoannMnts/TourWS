using TMPro;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Fights.UI
{
    public class PlayerSkillUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text skillName;
        [SerializeField]
        private TMP_Text skillDescription;
        
        public IFightSkill Current { get; private set; }
        
        private PlayerAttackPhaseUI playerAttackPhaseUI;
        
        public void Initialize(PlayerAttackPhaseUI phaseUI, IFightSkill skill)
        {
            Current = skill;
            playerAttackPhaseUI = phaseUI;
            
            skillName.text = skill.SkillData.Name;
            skillDescription.text = skill.SkillData.Description;
        }
        
        

        public void OnClick()
        {
            playerAttackPhaseUI.SelectSkill(Current);
        }
    }
}