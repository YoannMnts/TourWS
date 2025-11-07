using System;
using System.Linq;
using DG.Tweening;
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

        [SerializeField] 
        private MeshRenderer meshRenderer;

        [SerializeField] private Color validCellColor;
        [SerializeField] private Color notValidCellColor;
        
        private Color defaultCellColor;

        private void Awake()
        {
            defaultCellColor = meshRenderer.material.color;
        }

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

            currentSelectPhase = phase;
            meshRenderer.material.DOKill();
            if (phase.Cells.Contains(Coordinates))
                meshRenderer.material.DOColor(validCellColor, .3f);
            else
                meshRenderer.material.DOColor(notValidCellColor, .3f);
        }

        void IPhaseListener<SelectCellPhase>.OnPhaseEnd(SelectCellPhase phase)
        {
            if (phase == currentSelectPhase)
            {
                currentSelectPhase = null;
                meshRenderer.material.DOKill();
                meshRenderer.material.DOColor(defaultCellColor, .3f);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if(currentSelectPhase == null)
                return;
            
            transform.DOKill();
            transform.DOScale(Vector3.one * 1.2f, .3f).SetEase(Ease.OutExpo);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if(currentSelectPhase == null)
                return;
            
            transform.DOKill();
            transform.DOScale(Vector3.one, .3f).SetEase(Ease.OutExpo);
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (currentSelectPhase != null)
            {
                currentSelectPhase.SelectCell(Coordinates);
                transform.DOKill();
                transform.DOPunchScale(Vector3.one * 1.2f, .3f);
            }
        }
    }
}