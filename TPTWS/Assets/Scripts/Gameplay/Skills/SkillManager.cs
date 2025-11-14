using TPT.Core.Data;
using TPT.Core.Data.Skills;

namespace TPT.Gameplay.Skills
{
    public static class SkillManager
    {
        public static IFightSkill CreateSkillFromData(SkillData skillData) => skillData switch
        {
            StrikeSkillData strikeSkillData => new StrikeSkill(strikeSkillData),
            HealAllSkillData healAllSkillData => new HealAllSkill(healAllSkillData),
            _ => null,
        };
    }
}