using System.Collections.Generic;
using TPT.Core.Phases;
using UnityEngine;
using UnityEngine.Pool;

namespace TPT.Gameplay.Grids.Phases
{
    public class SelectCellPhase : IPhase
    {
        private readonly CellCoordinate startCoordinate;
        public readonly FightGrid grid;
        public readonly ICellPattern pattern;
        private List<CellCoordinate> cells;

        public bool HasSelected { get; private set;}
        public CellCoordinate SelectedCoordinate { get; private set;}
        
        public IReadOnlyList<CellCoordinate> Cells => cells.AsReadOnly();
        
        public SelectCellPhase(CellCoordinate startCoordinate, FightGrid grid, ICellPattern pattern)
        {
            this.startCoordinate = startCoordinate;
            this.grid = grid;
            this.pattern = pattern;
            HasSelected = false;
        }

        public void SelectCell(CellCoordinate coordinate)
        {
            SelectedCoordinate = coordinate;
            HasSelected = true;
        }
        
        Awaitable IPhase.Begin()
        {
            ListPool<CellCoordinate>.Get(out cells);
            pattern.GetCells(grid, startCoordinate, cells);
            
            return PhaseManager.CompletedPhase;
        }

        async Awaitable IPhase.Execute()
        {
            while (!HasSelected)
            {
                await Awaitable.NextFrameAsync();
            }
        }

        Awaitable IPhase.End()
        {
            ListPool<CellCoordinate>.Release(cells);
            return PhaseManager.CompletedPhase;
        }

    }
}