using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class StalactiteUp : MonoBehaviour, ITrapable
    {
        // Start is called before the first frame update
        void Start()
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                GetComponent<Rigidbody2D>().gravityScale = 2;
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                var player = other.gameObject.GetComponent<Player>();
                if (!player.HasHelmet)
                    other.gameObject.GetComponent<Player>().Death();
            }
            else
                Destroy(gameObject, 0.1f);
        }
    }
}
