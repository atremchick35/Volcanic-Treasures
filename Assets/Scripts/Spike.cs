using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Spike : MonoBehaviour, ITrapable
{
    private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            KillPlayer();
    }

    public void KillPlayer() => _player.Death();
}
