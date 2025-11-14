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
            Debug.Log("je tire");
            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = new AttackFloodFillPattern(Data.Range);
            return true;
        }
    }
}