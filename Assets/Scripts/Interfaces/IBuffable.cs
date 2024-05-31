using Interfaces;
using Player_Scripts;
using UnityEngine;

namespace Interfaces
{
    // Данный интерфейс задаёт "правила" всем существующим эффектам
    public interface IBuffable
    {
        void AddBuff();
        
        void RemoveBuff();
    }
}

namespace Buffs
{
    // Данный класс отвечает за все эффекты игрока, которые можно подобрать из сундука
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

            if (Player.Effects.ContainsKey(GetImage()))
                Player.Effects[GetImage()] = UsingTime;
            else
                Player.Effects.Add(GetImage(), UsingTime);
            
            Debug.Log("Item Given");

            
            Invoke(nameof(RemoveBuff), UsingTime);
        }
    }
}