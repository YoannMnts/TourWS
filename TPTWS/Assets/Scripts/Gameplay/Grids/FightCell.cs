using System.Linq;
using TPT.Core.Phases;
using TPT.Gameplay.Grids.Phases;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TPT.Gameplay.Grids
{
    public class FightCell : MonoBehaviour, IPhaseListener<SelectCellPhase>, 
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerClickHandler
    {
        public CellCoordinate Coordinates { get; private set; }
        private FightGrid grid;
        
        private SelectCellPhase currentSelectPhase;
        
        public void Bind(CellCoordinate cellCoordinate, FightGrid fightGrid)
        {
            Coordinates = cellCoordinate;
            grid = fightGrid;
        }

        public void Unbind()
        {
            
        }
        
        private void OnEnable()
        {
            this.AddListener();
        }

        private void OnDisable()
        {
            this.RemoveListener();
        }


        void IPhaseListener<SelectCellPhase>.OnPhaseBegin(SelectCellPhase phase)
        {
            if(phase.grid != grid)
                return;

            if (phase.Cells.Contains(Coordinates))
            {
                currentSelectPhase = phase;
            }
        }

        void IPhaseListener<SelectCellPhase>.OnPhaseEnd(SelectCellPhase phase)
        {
            if (phase == currentSelectPhase)
            {
                currentSelectPhase = null;
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (currentSelectPhase != null)
            {
                currentSelectPhase.SelectCell(Coordinates);
            }
        }
    }
}