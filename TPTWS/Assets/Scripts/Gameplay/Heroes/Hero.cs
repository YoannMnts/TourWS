using System;
using System.Collections.Generic;
using DG.Tweening;
using TPT.Core.Data;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases;
using TPT.Gameplay.FightPhases.Grids;
using TPT.Gameplay.Skills;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TPT.Gameplay.Heroes
{
    public abstract class Hero : MonoBehaviour, IFightHero, IGridMember
    {
        public bool IsAlive => CurrentHealth > 0;
        IReadOnlyList<IFightSkill> IFightHero.Skills => skills.AsReadOnly();

        public abstract bool IsPlayerHero { get; }
        
        
        [field: SerializeField]
        public HeroData HeroData { get; private set; }

        [field: SerializeReference]
        public List<IFightSkill> skills = new List<IFightSkill>();
        public int MovementSpeed { get; private set; } = 2;
        public int Speed { get; private set; } = 1;
        
        public int CurrentStrength { get; private set; }
        public int CurrentHealth { get; private set; } = 100;
        
        public CellCoordinate Coordinates { get; private set; }

        private void Awake()
        {
            Debug.Log($"hero {name} is Awake, Skills Count: {HeroData.Skills.Length}");
            MovementSpeed = HeroData.MovementRange;
            Speed = HeroData.Speed;
            for (int i = 0; i < HeroData.Skills.Length; i++)
            {
                var skillData = HeroData.Skills[i];
                var skill = SkillManager.CreateSkillFromData(skillData);
                if (skill != null)
                {
                    Debug.Log($"skill qui va s'ajouter : {skill}");
                    skills.Add(skill);
                }
            }
        }

        public async Awaitable OnTurnBegin()
        {
            Debug.Log($"Starting turn for {name}", gameObject);
            await Awaitable.WaitForSecondsAsync(.2f);
        }

        public async Awaitable OnTurnEnd()
        {
            Debug.Log($"Ending turn for {name}", gameObject);
            await Awaitable.WaitForSecondsAsync(.2f);
        }

        public FightGrid Grid { get; set; }
        public async Awaitable MoveTo(CellCoordinate targetCoordinates)
        {
            if (Coordinates.Equals(targetCoordinates))
            {
                await PhaseManager.CompletedPhase;
                return;
            }
            
            Coordinates = targetCoordinates;
            
            await transform.DOMove(Coordinates.position, .5f)
                .SetEase(Ease.OutQuint)
                .AsyncWaitForCompletion();
        }

        int IComparable<IFightHero>.CompareTo(IFightHero other)
        {
            return Speed.CompareTo(other.Speed);
        }
        
        public void AddOrRemoveHealth(int amount)
        {
            if (amount <= 0) 
                return;

            CurrentHealth += amount;
            CurrentHealth = Mathf.Max(CurrentHealth, 0);

            Debug.Log(name + " prend " + amount + " dégâts.");
            Debug.Log(name +" il te reste "+ CurrentHealth+" HP");

            if (CurrentHealth <= 0)
                Die(); 
        }

        private void Die()
        {
            //Faire un tas de trucs
        }
    }
}