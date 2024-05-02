using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Player_Scripts;
using UnityEngine;

public class StalactiteUp : MonoBehaviour, ITrapable
{
    private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !_player.HasHelmet)
            KillPlayer();
        else
            Destroy(gameObject, 0.1f);
    }

    public void KillPlayer() => _player.Death();
}
