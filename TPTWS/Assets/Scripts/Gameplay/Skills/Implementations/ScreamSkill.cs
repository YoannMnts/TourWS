using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
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
            pattern = null;
            return false;
        }
    }
}