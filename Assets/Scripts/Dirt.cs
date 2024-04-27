using System;
using UnityEngine;

public class Dirt : MonoBehaviour, IEffectable
{
    [SerializeField] private float slowdown;
    private Movement _player;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    private void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.speed *= slowdown;
            _player.jumpForce *= slowdown;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player.speed /= slowdown;
            _player.jumpForce /= slowdown;
        }
    }

    public void KillPlayer()
    {
    }
}
