using System.Collections;
using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Boots : MonoBehaviour, IEffectable
{
    [SerializeField] private float acceleration;
    [SerializeField] private float usingTime;
    private Movement _player;
    private bool _isClaimed;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_isClaimed)
        {
            _isClaimed = true;
            _player.speed *= acceleration;
            StartCoroutine(Timer(usingTime));
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Boots are claimed");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    }

    private IEnumerator Timer(float duration)  {
        // Eventual code to execute right as the function is called
        yield return new WaitForSeconds(duration);
        // The code from here will be executed after **duration** seconds
        Destroy(gameObject);
        _player.speed /= acceleration;
        Debug.Log("Boots are over");
    }
    
    public void KillPlayer()
    {
    }
}
