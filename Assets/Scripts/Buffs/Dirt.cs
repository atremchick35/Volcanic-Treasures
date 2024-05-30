using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    // Скрипт описывает логику эффекта (объекта) "Dirt"
    public class Dirt : MonoBehaviour, IBuffable
    {
        [SerializeField] private float slowdown;
        private Movement _movement;

        private void AddBuff(GameObject player)
        {
            _movement = player.GetComponent<Movement>();
            _movement.SetSpeed(slowdown);
            _movement.SetJumpForce(slowdown);
        }

        public void AddBuff()
        {
            // Не реализует
        }

        public void RemoveBuff()
        {
            _movement.ResetSpeed(slowdown);
            _movement.ResetJumpForce(slowdown);
        }
    
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                AddBuff(other.gameObject);
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                RemoveBuff();
        }
    }
}
