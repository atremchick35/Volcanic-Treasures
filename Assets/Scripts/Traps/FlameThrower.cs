using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class FlameThrower : MonoBehaviour, ITrapable
    {
        private Collider2D _fireCollider2D;
    
        // Start is called before the first frame update
        void Start()
        {
            _fireCollider2D = GetComponent<Collider2D>();
        }

        public void FireOn() => _fireCollider2D.enabled = true;

        public void FireOff() => _fireCollider2D.enabled = false;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                other.GetComponent<Player>().Death();
        }
    }
}
