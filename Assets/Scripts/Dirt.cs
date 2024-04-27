using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dirt : MonoBehaviour, IEffectable
{
    [SerializeField] private float slowdown;
    private Collider2D _collider2D;
    private bool _isContact;
    private Movement _player;
    
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_isContact)
            {
                _player.speed *= slowdown;
                _isContact = true;
            }
        }
        else if (_isContact)
        {
            Debug.Log("Speed is recovered");
            _player.speed /= slowdown;
            _isContact = false;
        }
    }
    
    public void KillPlayer()
    {
    }

	public void OnTriggerExit2D(Collider2D other)
	{
		
	}
}
