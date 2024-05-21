using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Coin : MonoBehaviour, IInteractable, ILootable
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
        if (!gameObject.CompareTag("Chest") && other.CompareTag("Player"))
        {
            _player.AddCoins(1);
            Destroy(gameObject);
            Debug.Log("Coin claimed");
        }
    }

    public void GivePlayer()
    {
        var coin = Random.Range(1, 5);
        _player.AddCoins(coin);
        Debug.Log($"Coin from chest claimed : {coin}");
    }
}