using System;
using UnityEngine;
using Utils;

namespace DefaultNamespace
{
    public class ValueDecreaser : MonoBehaviour
    {
        [SerializeField] private FloatRef Kanban;
        [SerializeField] private FloatRef Law;
        [SerializeField] private FloatRef Error;
        [SerializeField] private GameEvent LevelFailed;

        private void Update()
        {
            if (Kanban.Value < .5f || Law.Value < .5f || Error.Value < .5f)
            {
                LevelFailed.Raise();
            }
            else
            {
                //Kanban.Value -= .005f;
                Kanban.Value -= .05f;
                Law.Value -= .005f;
                Error.Value -= .005f;
            }
            
        }
    }
}