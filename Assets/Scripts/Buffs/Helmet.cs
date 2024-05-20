using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    public class Helmet : Buff
    {
        private Player _player;
    
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
            _player = player.GetComponent<Player>();
            _player.HasHelmet = true;
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Helmet is claimed");
        }

        public override void RemoveBuff()
        {
            _player.HasHelmet = false;
            Destroy(gameObject);
            Debug.Log("Helmet is over");
        }
    }
}
