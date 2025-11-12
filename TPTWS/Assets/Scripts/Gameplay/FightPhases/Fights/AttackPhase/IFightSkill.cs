using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.Fights.Attack
{
    public interface IFightSkill
    {
        Awaitable Perform(IFightHero hero, FightGrid grid, CellCoordinate cellCoordinate);
        bool GetPattern(out ICellPattern pattern);
    }
}