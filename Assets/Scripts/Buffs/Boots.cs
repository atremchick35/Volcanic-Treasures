using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Buffs
{
    public class Boots : Buff
    {
        [FormerlySerializedAs("Acceleration")] [SerializeField] 
        private float acceleration;
        
        private Movement _player;
    
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    
        public override void AddBuff(GameObject player)
        {
            IsClaimed = true;
            _player = player.GetComponent<Movement>();
            _player.SetSpeed(acceleration);
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Boots are claimed");
        }
    
        public override void RemoveBuff()
        {
            _player.ResetSpeed(acceleration);
            Destroy(gameObject);
            Debug.Log("Boots are over");
        }
    }
}
