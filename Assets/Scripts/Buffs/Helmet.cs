using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Buffs
{
    public class Helmet : MonoBehaviour, IBuffable
    {
        [FormerlySerializedAs("Using time")] [SerializeField] private float usingTime;
        private Player _player;
    
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public void AddBuff(GameObject player)
        {
            _player = player.GetComponent<Player>();
            _player.HasHelmet = true;
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Helmet is claimed");
        }

        public void RemoveBuff()
        {
            _player.HasHelmet = false;
            Destroy(gameObject);
            Debug.Log("Helmet is over");
        }

        public void OnTriggerEnter2D(Collider2D other) // вынести в абстрактный класс
        {
            if (other.CompareTag("Player"))
            {
                AddBuff(other.gameObject);
                Invoke(nameof(RemoveBuff), usingTime);
            }
        }
    }
}
