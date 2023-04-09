using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using Utils.RefValue;


public class PlatformController : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    [SerializeField] private bool _Isleft;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.TryGetComponent(out BallEmpty _Ball);
        if (_Ball)
        {
            if (_Isleft)
            {
                if(pivot.rotation.eulerAngles.z < 10 || pivot.rotation.eulerAngles.z > 345)
                    pivot.Rotate(0,0,5);
            }
            else
            {
                if(pivot.rotation.eulerAngles.z < 15 || pivot.rotation.eulerAngles.z > 350)
                    pivot.Rotate(0,0,-5);
            }

            LeanPool.Despawn(_Ball.gameObject);
        }
    }
}



