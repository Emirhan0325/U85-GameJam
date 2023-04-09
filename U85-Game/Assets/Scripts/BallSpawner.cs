using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using UnityEngine.UI;


public class BallSpawner : MonoBehaviour
{
    [SerializeField] public GameObject _PrefabBall;
    [SerializeField] public Transform _SpawnPoint;

    public bool _canPress = true;

    [SerializeField] private Button _SpawnButton;
    // [SerializeField] Animator _animator;
    void Start()
    {
        _SpawnButton.onClick.AddListener(OnSpawnButtonClick);
        // _animator = gameObject.GetComponent<Animator>();
    }


    public void OnSpawnButtonClick()
    {
        if (_canPress)
        {
            
            //StartCoroutine("SpawnPrefab");
            var _SpawnPosition = _SpawnPoint.position;
            var _SpawnRotaion = _SpawnPoint.rotation;
            var projectTile = LeanPool.Spawn(_PrefabBall, _SpawnPosition, _SpawnRotaion);
            // _animator.SetBool("Click",true);
            
        }
    }

    
      
    

    



}
