using System.Linq;
using Interfaces;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Interfaces
{
    public interface IBuffable
    {
        void AddBuff();
        
        void RemoveBuff();

        Image GetImage();
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
        
        public abstract Image GetImage();

        public void GivePlayer()
        {
            AddBuff();
            if (Player.Effects.ContainsKey(GetImage())) // Тут выпадает ошибка NullReference.
                Player.Effects[GetImage()] = UsingTime; // Скорее всего потому что скрипт(ботинок, колца и т.д.)
                                                        // вешается на сундук, в котором нет картинки.
            else
                Player.Effects.Add(GetImage(), UsingTime);
            Debug.Log("Item Given");
            Invoke(nameof(RemoveBuff), UsingTime);
        }
    }
}