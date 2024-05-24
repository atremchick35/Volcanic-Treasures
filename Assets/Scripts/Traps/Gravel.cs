using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Traps
{
    public class Gravel : MonoBehaviour, ITrapable
    {
        [FormerlySerializedAs("Delay")] [SerializeField] private float delay;
    
        // Start is called before the first frame update
        void Start()
        {
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
                Destroy(gameObject, delay);
        }
    }
}
