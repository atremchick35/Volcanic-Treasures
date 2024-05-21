using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Traps
{
    public class Gravel : MonoBehaviour, ITrapable
    {
        [FormerlySerializedAs("Delay")] [SerializeField] private float delay;
        
        private Collider2D _collider2D;
    
        // Start is called before the first frame update
        void Start()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Gravel crumbling");
                _collider2D.isTrigger = false;
                Destroy(gameObject, delay);
            }
        }
    }
}
