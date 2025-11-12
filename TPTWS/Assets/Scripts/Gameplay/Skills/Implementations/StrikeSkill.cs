using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids.Patterns;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.Skills
{
    public class StrikeSkill : FightSkill<StrikeSkillData>
    {
        public StrikeSkill(StrikeSkillData data) : base(data)
        {
        }

        public override Awaitable Perform(IFightHero skillOwner, FightGrid grid, CellCoordinate cellCoordinate)
        {
            for (int x = skillOwner.Coordinates.x; x < cellCoordinate.x; x++)
            {
                for (int y = skillOwner.Coordinates.y; y < cellCoordinate.y; y++)
                {
                    if (grid.TryGetMember(x, y, out IGridMember member) && member is IFightHero fightHero)
                    {
                        if(fightHero.IsPlayerHero != skillOwner.IsPlayerHero)
                            fightHero.AddOrRemoveHealth(Data.Damage * fightHero.CurrentStrength);
                    }
                }
            }

            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = new DirectionCellPattern(Data.Range);
            return false;
        }
    }
}