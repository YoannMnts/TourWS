using System.Collections.Generic;
using TPT.Core;
using TPT.Core.Core.HeroData;
using TPT.Gameplay.Player;
using TPT.Gameplay.Player.GlueCode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TPT.Gameplay.TurnManager
{
        public class TurnManager : MonoBehaviour
        {
                public static TurnManager Instance;
                public HeroData heroData;
                public HeroData EnemyData;
                public List<Unit> heroes = new List<Unit>();
                public List<Unit> enemies = new List<Unit>();

                private int heroIndex = 0;
                private int enemyIndex = 0;
                private bool heroTurn = true;
                private bool battleEnded = false;
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
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                                Debug.Log(currentHero.name + " doit jouer !");
                                currentHero.GetComponent<ATTInteraction>().SetCanAct(true);
                        }
                        // On attend que Attaque.cs appelle PlayerAttack()
                }

                void EnemyTurn()
                {
                        Unit currentEnemy = enemies[enemyIndex];

                        // Exemple : si Space = joue son tour
                        if (Input.GetKeyDown(KeyCode.Space))
                        {

                                Debug.Log(currentEnemy.name + " joue !");
                                Debug.Log(EnemyData.MaxHealth);

                                NextEnemy();
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
                        UnitAtt att = currentHero.GetComponent<UnitAtt>();

                        if (special)
                        {
                                Debug.Log(currentHero.name + " utilise l'attaque spéciale !");
                                att.EFF(target);
                        }
                        else
                        {
                                Debug.Log(currentHero.name + " attaque !");
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
