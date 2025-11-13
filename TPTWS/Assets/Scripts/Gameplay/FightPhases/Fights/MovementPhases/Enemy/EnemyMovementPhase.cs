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