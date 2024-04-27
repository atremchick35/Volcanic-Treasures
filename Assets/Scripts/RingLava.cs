using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingLava : MonoBehaviour, IEffectable
{
	public Player _player;
	public void KillPlayer()
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			_player.HasRingLava = true;
			StartCoroutine(SetVariableForDuration(5));
			GetComponent<Renderer>().enabled = false;
			Destroy(gameObject);
		}
	}

	private IEnumerator SetVariableForDuration(float duration)
	{
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
		_player.HasRingLava = false;
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
