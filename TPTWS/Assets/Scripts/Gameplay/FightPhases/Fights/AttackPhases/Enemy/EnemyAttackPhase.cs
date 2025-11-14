using System;
using System.Collections.Generic;
using System.Linq;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.Skills;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TPT.Gameplay.FightPhases.AttackPhases.Enemy
{
    public class EnemyAttackPhase : AttackPhase
    {
        public event Action<IFightSkill> OnAttackSelected;
        
        public IFightSkill SelectedFightSkill { get; private set; }
        public EnemyAttackPhase(HeroTurnPhase heroTurnPhase) : base(heroTurnPhase)
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
            
            int distance = Distance(enemy.Coordinates, nearest.Coordinates);
            if (distance <= 1)
            {
                int random = Random.Range(0, enemy.Skills.Count);
                IFightSkill skill = enemy.Skills[random];
                
                await skill.Perform(enemy, Grid, enemy.Coordinates);
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
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.x - b.x);
        }
    }
}