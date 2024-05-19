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
        public IBuffable[] Effects { get; set; }
        
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Door") && Key && Key.CompareTag("DoorKey"))
            {
                other.collider.isTrigger = true;
                Key.Rigidbody.velocity = new Vector2(0, 0);
                Destroy(Key.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Chest") && Key && Key.CompareTag("ChestKey"))
            {
                other.GetComponent<Animator>().SetTrigger("ChestOpen");
                Key.Rigidbody.velocity = new Vector2(0, 0);
                Destroy(Key.gameObject);
            }
        }
    }
}
