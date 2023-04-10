using System;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace DefaultNamespace
{
    public class SliderController : MonoBehaviour
    {
        [SerializeField] private Slider Bar;
        [SerializeField] private FloatRef Amount;

        private void Start()
        {
            Bar.value = Amount.Value;
        }

        private void Update()
        {
            Bar.value = Amount.Value;
        }
    }
}