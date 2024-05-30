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
        protected Canvas Canvas;
        
        private void Awake()
        {
            var player = GameObject.FindWithTag("Player");
            Player = player.GetComponent<Player>();
            Movement = player.GetComponent<Movement>();
            Canvas = GameObject.FindWithTag("Canvas").GetComponent<Canvas>();
        }

        public abstract void AddBuff();
        
        public abstract void RemoveBuff();
        
        public abstract Transform GetImage();
        
        public void GivePlayer()
        {
            AddBuff();
            var image = GetImage();
            // if (Player.Effects.ContainsKey(image))
            //     Player.Effects[image] = UsingTime;
            // else
            //     Player.Effects.Add(image, UsingTime);
            Player.Effects[image] = UsingTime;
            Debug.Log("Item Given");
            Invoke(nameof(RemoveBuff), UsingTime);
        }
    }
}