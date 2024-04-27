using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteUp : MonoBehaviour, IEffectable
{
    // если игрок находится рядом, то падает(брать область внизу стены)
    // как только сталкивается с коллайдером пола, уничтожается(можно сделать небольшую задержку)

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

    public void OnTriggerEnter2D(Collider2D other) // Stay?
    {
        if (other.CompareTag("Player"))
            GetComponent<Rigidbody2D>().gravityScale = 2;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !_player.hasHelmet)
            KillPlayer();
        else
            Destroy(gameObject, 0.1f);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    }

    public void KillPlayer() => _player.Death();
}
