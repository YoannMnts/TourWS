using System.Collections.Generic;
using System.Linq;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.Grids.Phases;
using TPT.Gameplay.Fights;
using TPT.Gameplay.Grids;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.Fights.MovementPhase.Enemy
{
    public class EnemyMovementPhase : Gameplay.Fights.MovementPhase.MovementPhase
    {
        public EnemyMovementPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
        {
        }

        protected override async Awaitable Execute()
        {
            var pattern = new FloodFillPattern(Hero.MovementSpeed);
            var heroesCells = heroTurnPhase.heroesCells;

            var selectCellPhase = new SelectCellPhase(Hero.Coordinates, Grid, pattern, heroesCells);
            await ((IPhase)selectCellPhase).Begin(); 

            if (heroesCells == null || heroesCells.Count == 0)
                return;

            var start = Hero.Coordinates;
            var closestHero = heroesCells.OrderBy(h => Distance(start, h)).First();

            var target = GetClosestCell(selectCellPhase.Cells, closestHero);

            selectCellPhase.SelectCell(target);

            await ((IPhase)selectCellPhase).Execute();

            await Hero.MoveTo(target);
        }

        private CellCoordinate GetClosestCell(IReadOnlyList<CellCoordinate> cells, CellCoordinate hero)
        {
            return cells.OrderBy(c => Distance(c, hero)).First();
        }

        private int Distance(CellCoordinate a, CellCoordinate b)
        {
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        }
    }
}
