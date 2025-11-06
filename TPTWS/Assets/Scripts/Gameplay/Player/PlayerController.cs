using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace TPT.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        public Transform[] GetHeroPosition() => heroSpawnPoints;

        [SerializeField]
        private Transform[] heroSpawnPoints;
    }
}