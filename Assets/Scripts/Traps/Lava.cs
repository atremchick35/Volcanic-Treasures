using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Lava : MonoBehaviour, ITrapable
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

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_player.HasRingLava)
            KillPlayer();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
    }

    public void KillPlayer() => _player.Death();
}
