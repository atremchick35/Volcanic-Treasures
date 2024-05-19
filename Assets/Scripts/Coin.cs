using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable
{
    private Player _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.AddCoins(1);
            Destroy(gameObject);
            Debug.Log("Coin claimed");
        }
    }
}