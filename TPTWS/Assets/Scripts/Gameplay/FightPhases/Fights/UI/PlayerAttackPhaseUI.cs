using DG.Tweening;
using TMPro;
using TPT.Core.Phases;
using TPT.Gameplay.FightPhases.AttackPhases.Player;
using TPT.Gameplay.Skills;
using UnityEngine;

namespace TPT.Gameplay.FightPhases.UI
{
    public class PlayerAttackPhaseUI : MonoBehaviour, IPhaseListener<PlayerAttackPhase>
    {
        [SerializeField]
        private GameObject skillUIPrefab;

        [SerializeField]
        private Transform skillRoot;

        [SerializeField]
        public Transform[] stats;
        
        [SerializeField] 
        private CanvasGroup group;

        private PlayerAttackPhase current;

        private void Start()
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
            group.interactable = false;
        }

        private void OnEnable()
        {
            this.AddListener();
        }

        private void OnDisable()
        {
            this.RemoveListener();
        }
        public void OnPhaseBegin(PlayerAttackPhase phase)
        {
            Debug.Log("AAAAA");
            group.DOFade(1, 0.2f);
            group.blocksRaycasts = true;
            group.interactable = true;
            
            current = phase;
            foreach (Transform t in skillRoot)
                Destroy(t.gameObject);

            IFightHero currentHero = phase.heroTurnPhase.hero;

            foreach (IFightSkill skill in currentHero.Skills)
            {
                GameObject instance = Instantiate(skillUIPrefab, skillRoot);
                if (instance.TryGetComponent(out PlayerSkillUI skillUI))
                    skillUI.Initialize(this, skill);
            }

            for (int i = 0; i < stats.Length; i++)
            {
                if(stats[i].TryGetComponent(out PlayerStatUI statUI))
                    statUI.Initialize(currentHero, i);
            }
        }

        public void OnPhaseEnd(PlayerAttackPhase phase)
        {
            group.DOFade(0, 0.2f);
            group.blocksRaycasts = false;
            group.interactable = false;
            
            foreach (Transform t in skillRoot)
                Destroy(t.gameObject);
        }
        

        public void SelectSkill(IFightSkill skill)
        {
            current.SelectSkill(skill);
        }

    }
}