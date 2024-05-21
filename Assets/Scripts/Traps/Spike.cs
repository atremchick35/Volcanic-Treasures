using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class Spike : MonoBehaviour, ITrapable
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                other.GetComponent<Player>().Death();
        }
    }
}
