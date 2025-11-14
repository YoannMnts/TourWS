using TPT.Core.Data;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public interface IFightSkill
    {
        SkillData SkillData { get; }
        Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate);
        bool GetPattern(out ICellPattern pattern);
    }
}