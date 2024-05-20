using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    public class Boots : MonoBehaviour, IBuffable
    {
        [SerializeField] private float acceleration;
        [SerializeField] private float usingTime;
        private Movement _player;
        private bool _isClaimed;
    
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
            _isClaimed = true;
            _player = player.GetComponent<Movement>();
            _player.SetSpeed(acceleration);
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Boots are claimed");
        }
    
        public void RemoveBuff()
        {
            _player.ResetSpeed(acceleration);
            Destroy(gameObject);
            Debug.Log("Boots are over");
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_isClaimed)
            {
                AddBuff(other.gameObject);
                Invoke(nameof(RemoveBuff), usingTime);
            }
        }
    }
}
