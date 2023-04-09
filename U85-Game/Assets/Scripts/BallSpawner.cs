using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;
using UnityEngine.UI;


public class BallSpawner : MonoBehaviour
{
    [SerializeField] public GameObject PrefabBall;

    public void OnSpawnButtonClick()
    {
        var paper = LeanPool.Spawn(PrefabBall, transform);
    }
}
