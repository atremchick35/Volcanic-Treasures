using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingLava : MonoBehaviour, IEffectable
{
	private Player _player;
	private Lavash _lavash;
	public void KillPlayer()
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		
	}

	private IEnumerator SetVariableForDuration(float duration)
	{
		yield return new WaitForSeconds(duration);
		_player.HasRingLava = false;
		Destroy(gameObject);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			_player.HasRingLava = true;
			StartCoroutine(SetVariableForDuration(5));
			GetComponent<Renderer>().enabled = false;
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
