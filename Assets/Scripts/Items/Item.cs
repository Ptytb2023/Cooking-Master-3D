using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour, IPoolable
    {
        [SerializeField] private string _id;

        public string Id => _id;

        public void Despawn()
        {
        }

        public void Spawn()
        {
        }
    }
}
