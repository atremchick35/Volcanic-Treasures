using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Helmet : MonoBehaviour, IEffectable
{
    private Player _player;
    private bool _isClaimed;
    [FormerlySerializedAs("Using time")] [SerializeField] private float usingTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
            _player.hasHelmet = true;
            StartCoroutine(Timer(usingTime));
            GetComponent<Renderer>().enabled = false;
            Debug.Log("Helmet is claimed");
        }
    }
    
    private IEnumerator Timer(float duration)  {
        // Eventual code to execute right as the function is called
        yield return new WaitForSeconds(duration);
        // The code from here will be executed after **duration** seconds
        Destroy(gameObject);
        _player.hasHelmet = false;
        Debug.Log("Helmet is over");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
    }

    public void KillPlayer()
    {
    }
}
