using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class RandomBookSpawner : MonoBehaviour
    {
        [SerializeField] private List<BallSpawner> Spawners;
        [SerializeField] private float RepeatTime;

        private float _timeLeft;

        private void Update()
        {
            //timer
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
            {
                Spawners[Random.Range(0, 2)].OnSpawnButtonClick();
                _timeLeft = RepeatTime;
            }
        }
    }
}