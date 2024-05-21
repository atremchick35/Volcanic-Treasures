using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class Lava : MonoBehaviour, ITrapable
    {
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !other.GetComponent<Player>().HasRingLava)
                other.GetComponent<Player>().Death();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        
        }
    }
}
