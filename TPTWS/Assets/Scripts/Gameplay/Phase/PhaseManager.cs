using System;
using TPT.Gameplay.Player;
using UnityEngine;

namespace TPT.Gameplay.Gameplay.Phase
{
    public class PhaseManager : MonoBehaviour
    {
        [SerializeField]
        private GridManager gridManager;
        [SerializeField]
        private PlayerController player;
        
        private MovementPhase movementPhase;
        private AttackPhase attackPhase;

        private void StartFight(int gridIndex)
        {
            gridManager.GenerateGrids(gridIndex);
            gridManager.InitializeHeroPositionOnCell(player.GetHeroPosition());
            movementPhase.EnterInMovementPhase();
        }

        private void EndFight()
        {
            throw new NotImplementedException();
        }
    }
}