using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class Range
    {
        [field: SerializeField] public float Max { get; private set; }
        [field: SerializeField] public float Min { get; private set; }
    }
}
