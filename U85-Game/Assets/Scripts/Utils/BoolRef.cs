using UnityEngine;

namespace Utils
{
    [CreateAssetMenu]
    public class BoolRef : ScriptableObject
    {
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
            }
        }

        private bool _value; 
    }
}