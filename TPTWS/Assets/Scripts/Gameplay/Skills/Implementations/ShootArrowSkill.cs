using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public class ShootArrowSkill : FightSkill<ShootArrowSkillData>
    {
        public ShootArrowSkill(ShootArrowSkillData data) : base(data)
        {
        }

        public override Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate)
        {
            if (grid.TryGetMember(cellCoordinate.x, cellCoordinate.y, out IGridMember member) && member is IFightHero fightHero)
            {
                Debug.Log("Strike skill performed");
                Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
                if(fightHero.IsPlayerHero != skillOwner.IsPlayerHero)
                    fightHero.AddOrRemoveHealth(-Data.Damage); //* fightHero.CurrentStrength
                Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
            }

            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = new AttackFloodFillPattern(Data.Range);
            return true;
        }
    }
}