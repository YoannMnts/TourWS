using UnityEngine;
using UnityEngine.AI;

namespace TPT.Gameplay.Players
{
        [RequireComponent(typeof(NavMeshAgent))]
        public class FollowCharacter : MonoBehaviour
        {
                [SerializeField] private Transform target; // la cible à suivre (ex: joueur)
                [SerializeField] private float followDistance = 2f; // distance minimale avant d'arrêter de bouger
                private NavMeshAgent agent;

                void Start()
                {
                        agent = GetComponent<NavMeshAgent>();

                        if (target == null)
                        {
                                // Essaie de trouver le joueur automatiquement
                                GameObject player = GameObject.FindWithTag("Player");
                                if (player != null)
                                        target = player.transform;
                                else
                                        Debug.LogWarning($"{name}: Aucun joueur trouvé !");
                        }
                }

                void Update()
                {
                        if (target == null)
                                return;

                        float distance = Vector3.Distance(transform.position, target.position);

                        // Déplace le PNJ seulement s’il est trop loin
                        if (distance > followDistance)
                        {
                                agent.isStopped = false;
                                agent.SetDestination(target.position);
                        }
                        else
                        {
                                agent.isStopped = true;
                        }
                }
        }
}