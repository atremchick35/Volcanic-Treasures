using System;
using Interfaces;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

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