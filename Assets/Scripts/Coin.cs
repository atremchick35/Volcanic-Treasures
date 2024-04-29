using System;
using Interfaces;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Coin : MonoBehaviour, IInteractable
{
    private void Start()
    {
    }

    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.AddCoins(1);
            Destroy(gameObject);
            Debug.Log("Coin claimed");
        }
    }
}