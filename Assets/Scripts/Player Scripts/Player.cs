using System.Collections.Generic;
using Interfaces;
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
        public List<IBuffable> Effects { get; set; }

        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;
        public void Death() => Destroy(gameObject);
    
        // Start is called before the first frame update
        void Start()
        {
            Coins = 0;
            Diamonds = 0;
        }
        
        // Update is called once per frame
        void Update()
        {
        }
    }
}
