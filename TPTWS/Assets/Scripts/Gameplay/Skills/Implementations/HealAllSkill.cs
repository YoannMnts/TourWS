using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public class HealAllSkill : FightSkill<HealAllSkillData>
    {
        public HealAllSkill(HealAllSkillData data) : base(data)
        {
            
        }

        public override Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate)
        {
            foreach ((IGridMember gridMember, CellCoordinate memberCoord) in grid.Members)
            {
                if (gridMember is IFightHero fightHero && fightHero.IsPlayerHero == skillOwner.IsPlayerHero)
                {
                    fightHero.AddOrRemoveHealth(Data.Heal);
                }
            }
            
            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = null;
            return false;
        }
    }
}