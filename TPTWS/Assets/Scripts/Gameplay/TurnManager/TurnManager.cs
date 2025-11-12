/*
using System.Collections.Generic;
using TPT.Gameplay.PNJ;
using TPT.Gameplay.Player;
using TPT.Gameplay.Player.GlueCode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.TurnManager
{
        public class TurnManager : MonoBehaviour
        {
                public static TurnManager Instance;
                public InteractPNJ GO;
                public List<Unit> heroes = new List<Unit>();
                public List<Unit> enemies = new List<Unit>();

                private int heroIndex = 0;
                private int enemyIndex = 0;
                private bool heroTurn = true;
                private bool battleEnded = false;
                private bool  enemyActing = false;
                public int HeroIndex => heroIndex;
                public int EnemyIndex => enemyIndex;
                private PlayerInput playerInput;

                void Awake()
                {
                        if (Instance != null && Instance != this)
                        {
                                Destroy(gameObject);
                                return;
                        }
                        Instance = this;
                }

                void Update()
                {
                        // Arrêt si une équipe n’a plus d’unités
                        if (heroes.Count == 0 || enemies.Count == 0)
                        {
                                EndBattle();
                                return;
                        }

                        if (heroTurn)
                        {
                                HeroTurn();
                        }
                        else
                                EnemyTurn();
                }

                void HeroTurn()
                {
                        Unit currentHero = heroes[heroIndex];
                        if (Input.GetKeyDown(KeyCode.Space)&& GO.fighting)
                        {
                                Debug.Log(currentHero.name + " doit jouer !");
                                currentHero.GetComponent<ATTInteraction>().SetCanAct(true);
                        }
                        // On attend que Attaque.cs appelle PlayerAttack()
                }

                void EnemyTurn()
                {
                        Unit currentEnemy = enemies[enemyIndex];
                        Unit target =  heroes[heroIndex];
                        // Exemple : si Space = joue son tour
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                                Debug.Log(currentEnemy.name + " joue !");
                                StartCoroutine(EnemyAttackRoutine());
                                
                        }

                        IEnumerator EnemyAttackRoutine()
                        {
                                Unit currentEnemy = enemies[enemyIndex];
                                Unit target = heroes[heroIndex];

                                Debug.Log(currentEnemy.name + " prépare une attaque...");
                                yield return new WaitForSeconds(1.5f); 

                                if (currentEnemy != null && target != null)
                                {
                                        Debug.Log(currentEnemy.name + " attaque " + target.name);
                                        currentEnemy.Attack(target);
                                }

                                yield return new WaitForSeconds(0.5f);

                                NextEnemy();
                                enemyActing = false;
                        }

                }

                public void NextHero()
                {
                        heroIndex++;
                        if (heroIndex >= heroes.Count)
                        {
                                heroIndex = 0;
                                heroTurn = false;

                        }
                }

                void NextEnemy()
                {
                        enemyIndex++;
                        if (enemyIndex >= enemies.Count)
                        {
                                enemyIndex = 0;
                                heroTurn = true;

                        }

                }

                public void PlayerAttack(bool special)
                {
                        Unit currentHero = heroes[heroIndex];
                        Unit target = enemies[enemyIndex];
                        Unit att = currentHero.GetComponent<Unit>();

                        if (special)
                        {
                                
                                att.EFF(target);
                        }
                        else
                        {
                                
                                att.Attack(target);
                        }

                        NextHero();
                }

                public void RemoveUnit(Unit unit)
                {
                        if (heroes.Contains(unit))
                        {
                                heroes.Remove(unit);
                        }
                        else if (enemies.Contains(unit))
                        {
                                enemies.Remove(unit);
                        }
                }

                void EndBattle()
                {
                        if (battleEnded) return;

                        if (heroes.Count == 0)
                                Debug.Log("Les ennemis ont gagné !");
                        else if (enemies.Count == 0)
                                Debug.Log("Les héros ont gagné !");

                        battleEnded = true;
                }
        }
}
*/