using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = nameof(ScriptableObject) + "/" + nameof(PlayerConfig), order = 51)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float StartMovmentSpeed { get; private set; }
    }
}
