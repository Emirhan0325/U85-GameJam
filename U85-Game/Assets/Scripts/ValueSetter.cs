using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class ValueSetter : MonoBehaviour
    {
        [SerializeField] private FloatRef Value;
        [SerializeField] private float StartValue;

        private void Start()
        {
            Value.Value = StartValue;
        }
    }
}