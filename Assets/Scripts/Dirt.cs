using System;
using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Dirt : MonoBehaviour, IBuffable
{
    [FormerlySerializedAs("Slowdown")][SerializeField] private float slowdown;
    private Movement _player;

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void AddBuff(GameObject player)
    {
        _player = player.GetComponent<Movement>();
        _player.SetSpeed(slowdown);
        _player.SetJumpForce(slowdown);
    }

    public void RemoveBuff()
    {
        _player.ResetSpeed(slowdown);
        _player.ResetJumpForce(slowdown);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            AddBuff(other.gameObject);
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            RemoveBuff();
    }

	public void OnTriggerExit2D(Collider2D other)
	{
		
	}
}
