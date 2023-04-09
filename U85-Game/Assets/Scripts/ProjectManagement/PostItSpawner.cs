using System;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProjectManagement
{
    public class PostItSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject PostIt;
        [SerializeField] private float RepeatTime;
        public AudioSource _audio;

        private float _timeLeft;

        private void Update()
        {
            //timer
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
            {
                SpawnPostIt();
                _timeLeft = RepeatTime;
            }
        }

        private void SpawnPostIt()
        {
            _audio.Play();
            var newPositionX = Random.Range(-8, -6);
            var newPositionY = Random.Range(-4, 4);
            var newVector = new Vector2(newPositionX, newPositionY);
            var paper = LeanPool.Spawn(PostIt, transform);
            paper.transform.localScale = Vector3.zero;
            paper.transform.position = newVector;
            paper.transform.DOScale(Vector3.one, .5f);
        }
        
    }
}