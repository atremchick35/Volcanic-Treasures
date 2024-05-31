using System.Collections.Generic;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        private int Coins { get; set; }
        private int Diamonds { get; set; }
        public bool HasHelmet { get; set; }
        public bool HasRingLava { get; set; }
        public Key Key { get; set; }
        public Dictionary<Transform, float> Effects { get; } = new();

        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;
        public void Death() => Destroy(gameObject);
    }
}
