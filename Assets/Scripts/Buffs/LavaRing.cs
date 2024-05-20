using Player_Scripts;
using UnityEngine;

namespace Buffs
{
    public class LavaRing : Buff
    {
        private Player _player;
        private Renderer _renderer;
    
        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public override void AddBuff(GameObject player)
        {
            _player = player.GetComponent<Player>();
            _player.HasRingLava = true;
            _renderer.enabled = false;
        }

        public override void RemoveBuff()
        {
            _player.HasRingLava = false;
            Destroy(gameObject);
        }
    }
}
