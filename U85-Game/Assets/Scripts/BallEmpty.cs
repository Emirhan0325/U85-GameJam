using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class BallEmpty : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        col.TryGetComponent(out PlatformController _PlatformController);
        if (_PlatformController)
        {
            LeanPool.Despawn(gameObject, 2f);
        }
    }
}
