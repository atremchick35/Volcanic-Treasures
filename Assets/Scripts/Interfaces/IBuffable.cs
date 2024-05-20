using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interfaces
{
    public interface IBuffable
    {
        void AddBuff(GameObject player);
        void RemoveBuff();
    }
}

namespace Buffs
{
    public abstract class Buff : MonoBehaviour, IBuffable
    {
        [FormerlySerializedAs("Using time")] [SerializeField] 
        private float usingTime;
        
        protected bool IsClaimed;

        public abstract void AddBuff(GameObject player);

        public abstract void RemoveBuff();
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !IsClaimed)
            {
                AddBuff(other.gameObject);
                Invoke(nameof(RemoveBuff), usingTime);
            }
        }
    }
}