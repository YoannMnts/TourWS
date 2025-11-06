using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;

namespace TPT.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Transform[] GetHeroPosition() => spawnPoints;

        [SerializeField]
        private Transform[] spawnPoints;
    }
}