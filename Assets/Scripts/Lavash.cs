using Player_Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavash : MonoBehaviour, IEffectable
{
	private Player _player;

	public void KillPlayer()
	{
		_player.Death();
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !_player.HasRingLava)
		{
			KillPlayer();
		}
	}

	public void OnTriggerExit2D(Collider2D other)
	{
	}

	// Start is called before the first frame update
	void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
