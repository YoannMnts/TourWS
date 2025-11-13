using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using TPT.Gameplay.FightPhases.Grids.Phases;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public class ScreamSkill : FightSkill<ScreamSkillData>
    {
        public ScreamSkill(ScreamSkillData data) : base(data)
        {
        }

        public override Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate)
        {
            Debug.Log("ScreamSkill performed");
            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = new FloodFillPattern(Data.Range);
            return true;
        }
    }
}