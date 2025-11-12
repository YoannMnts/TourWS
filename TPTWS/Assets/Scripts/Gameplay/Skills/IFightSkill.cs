using TPT.Core.Data;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
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