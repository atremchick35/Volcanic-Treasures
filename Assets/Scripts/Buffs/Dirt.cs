using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Buffs
{
    public class Dirt : MonoBehaviour, IBuffable
    {
        [FormerlySerializedAs("Slowdown")][SerializeField] 
        private float slowdown;
        
        private Movement _movement;

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void AddBuff(GameObject player)
        {
            _movement = player.GetComponent<Movement>();
            _movement.SetSpeed(slowdown);
            _movement.SetJumpForce(slowdown);
        }

        public void AddBuff()
        {
            
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
        
        public Image GetImage() => GetComponent<Image>();
    }
}
