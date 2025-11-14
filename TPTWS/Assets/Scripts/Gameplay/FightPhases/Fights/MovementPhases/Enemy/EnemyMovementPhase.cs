using System.Collections.Generic;
using System.Linq;
using TPT.Gameplay.FightPhases.Grids;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.MovementPhases.Enemy
{
	public class EnemyMovementPhase : MovementPhase
	{
		public EnemyMovementPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
		{
		}

		protected override async Awaitable Execute()
		{
			List<IFightHero> playerHeroes = new List<IFightHero>();
			GetPlayerHeroes(playerHeroes);
			
			IFightHero enemy = heroTurnPhase.hero;
			IFightHero nearest = GetNearestHero(playerHeroes);
			if (nearest == null)
				return;

			CellCoordinate enemyCoordinates = enemy.Coordinates;
			
			Vector2 direction = new Vector2Int()
			{
				x = nearest.Coordinates.x - enemyCoordinates.x,
				y = nearest.Coordinates.y - enemyCoordinates.y,
			};
			
			Vector2 movement = direction.normalized * enemy.MovementSpeed;

			Vector2Int targetCoord = new Vector2Int()
			{
				x = enemyCoordinates.x + Mathf.FloorToInt(movement.x),
				y = enemyCoordinates.y + Mathf.FloorToInt(movement.y),
			};

			bool doesCellExists = Grid.TryGetCell(targetCoord.x, targetCoord.y, out FightCell cell);
			bool isCellOccupied = doesCellExists && Grid.TryGetMember(cell.Coordinates, out _);
			
			if (doesCellExists && !isCellOccupied)
			{
				await Grid.MoveMember(enemy,  cell.Coordinates);
			}
		}

		private IFightHero GetNearestHero(List<IFightHero> playerHeroes)
		{
			IFightHero nearest = null;
			int minDistance = int.MaxValue;
			IFightHero enemy = heroTurnPhase.hero;
			
			foreach (IFightHero playerHero in playerHeroes)
			{
				int currentDistance = Distance(playerHero.Coordinates, enemy.Coordinates);
				if (currentDistance < minDistance)
				{
					minDistance = currentDistance;
					nearest = playerHero;
				}
			}

			return nearest;
		}

		private void GetPlayerHeroes(List<IFightHero> playerHeroes)
		{
			Dictionary<IGridMember, CellCoordinate> members = Grid.Members;

			foreach (IGridMember member in members.Keys)
			{
				if (member is IFightHero hero && hero.IsPlayerHero)
					playerHeroes.Add(hero);
			}
		}
		
		private int Distance(CellCoordinate a, CellCoordinate b)
		{
			return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
		}
	}
}