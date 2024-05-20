using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class FlameThrower : MonoBehaviour, ITrapable
    {
        private Collider2D _fireCollider2D;
        private Player _player;
    
        // Start is called before the first frame update
        void Start()
        {
            _fireCollider2D = GetComponent<Collider2D>();
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void FireOn() => _fireCollider2D.enabled = true;

        public void FireOff() => _fireCollider2D.enabled = false;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                KillPlayer();
        }

        public void KillPlayer() => _player.Death();
    }
}
