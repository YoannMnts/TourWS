using TPT.Core.Data.Skills;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.FightPhases.Grids.Patterns;
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
            if (grid.TryGetMember(cellCoordinate.x, cellCoordinate.y, out IGridMember member) && member is IFightHero fightHero)
            {
                Debug.Log("Strike skill performed");
                Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
                if(fightHero.IsPlayerHero != skillOwner.IsPlayerHero)
                    fightHero.AddOrRemoveHealth(-Data.Damage); //* fightHero.CurrentStrength
                Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
            }
            for (int x = skillOwner.Coordinates.x; x < cellCoordinate.x; x++)
            {
                /*
                Debug.Log("Je suis le X");
                for (int y = skillOwner.Coordinates.y; y < cellCoordinate.y; y++)
                {
                    Debug.Log("Je suis le Y");
                    if (grid.TryGetMember(x, y, out IGridMember member) && member is IFightHero fightHero)
                    {
                        Debug.Log("Strike skill performed");
                        Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
                        if(fightHero.IsPlayerHero != skillOwner.IsPlayerHero)
                            fightHero.AddOrRemoveHealth(Data.Damage * fightHero.CurrentStrength);
                        Debug.Log($"Hero {fightHero.HeroData.name} health : {fightHero.CurrentHealth}");
                    }
                }
                */
            }

            return PhaseManager.CompletedPhase;
        }

        public override bool GetPattern(out ICellPattern pattern)
        {
            pattern = new DirectionCellPattern(Data.Range);
            return true;
        }
    }
}