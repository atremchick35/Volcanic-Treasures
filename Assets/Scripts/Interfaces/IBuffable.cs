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
    public abstract class LootBuffs : MonoBehaviour, ILootable
    {
        private const float UsingTime = 10f;
        protected Player Player;
        protected Movement Movement;
        protected Canvas Canvas;

        private const string CanvasTag = "Canvas";
        private const string PlayerTag = "Player";


        private void Awake()
        {
            var player = GameObject.FindWithTag(PlayerTag);
            Canvas = GameObject.FindWithTag(CanvasTag).GetComponent<Canvas>();
            Player = player.GetComponent<Player>();
            Movement = player.GetComponent<Movement>();
        }

        protected abstract void AddBuff();

        protected abstract void RemoveBuff();
        
        protected abstract Transform GetImage();

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