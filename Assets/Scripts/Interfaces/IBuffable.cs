using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Interfaces
{
    public interface IBuffable
    {
        void AddBuff();
        
        void RemoveBuff();
    }
}

namespace Buffs
{
    public abstract class LootBuffs : MonoBehaviour, IBuffable, ILootable
    {
        private const float UsingTime = 10f;
        protected Player Player;
        protected Movement Movement;

        private void Awake()
        {
            var player = GameObject.FindWithTag("Player");
            Player = player.GetComponent<Player>();
            Movement = player.GetComponent<Movement>();
        }

        public abstract void AddBuff();

        public abstract void RemoveBuff();

        public void GivePlayer()
        {
            AddBuff();
            Invoke(nameof(RemoveBuff), UsingTime);
        }
    }
}