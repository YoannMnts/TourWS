using TPT.Core.Data;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public abstract class FightSkill<T> : IFightSkill where T : SkillData
    {
        public SkillData SkillData => Data;
        public T Data { get; private set; }

        protected FightSkill(T data)
        {
            Data = data;
        }
        
        public abstract Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate);
        public abstract bool GetPattern(out ICellPattern pattern);
    }
}