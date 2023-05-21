using System;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Cells;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class DictionaryFormatter<TKey, TValue> : ISerializationCallbackReceiver
    {
        public Dictionary<TKey, TValue> Dictionary = new();

        [SerializeField] private TKey[] _keys;
        [SerializeField] private TValue[] _values;

        public void OnBeforeSerialize()
        {
            _keys = Dictionary.Keys.ToArray();
            _values = Dictionary.Values.ToArray();
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < _keys.Length; i++)
                Dictionary.Add(_keys[i], _values[i]);
        }
        
        public TValue this[TKey index]
        {
            get => Dictionary[index];
            set => Dictionary[index] = value;
        }
    }
}