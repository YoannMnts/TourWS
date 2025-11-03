using TPT.Core.Data.Skills;
using TPT.Gameplay.Heroes;
using TPT.Gameplay.Heroes.Skills;
using UnityEngine;

namespace TPT.Gameplay
{
    [CreateSkillFor(typeof(DamageAllSkillData))]
    public class DamageAllSkill : Skill<DamageAllSkillData>
    {
        public override bool CanBeUsed()
        {
            return true;
        }

        protected override void Initialize()
        {
            
        }

        protected override void OnUse(SkillUsageContext context)
        {
            int damage = Data.Damage;
            int realDamage = damage * context.from.CurrentStrength;

            foreach (Hero target in context.targets)
            {
                target.AddOrRemoveHealth(-realDamage);
            }
        }
    }
}
