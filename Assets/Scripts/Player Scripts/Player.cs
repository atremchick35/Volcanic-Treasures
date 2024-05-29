using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public int Coins { get; set; }
        public int Diamonds { get; set; }
        public bool HasHelmet { get; set; }
        public bool HasRingLava { get; set; }
        public Key Key { get; set; }
        public Dictionary<Transform, float> Effects { get; set; }

        public void AddCoins(int coinsAmount) => Coins += coinsAmount;
        public void AddDiamonds(int diamondsAmount) => Diamonds += diamondsAmount;
        public void Death() => Destroy(gameObject);
        
        // Start is called before the first frame update
        void Awake()
        {
            Effects = new();
        }
        
        // Update is called once per frame
        void Update()
        {
        }
    }
}
