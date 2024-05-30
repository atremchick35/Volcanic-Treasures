using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Traps
{
    public class Gravel : MonoBehaviour, ITrapable
    {
        [SerializeField] private float delay;
        [SerializeField] private Sprite crack;
    
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
            {
                foreach (var block in gameObject.GetComponentsInChildren<SpriteRenderer>())
                    block.sprite = crack;
                Destroy(gameObject, delay);
            }
        }
    }
}
