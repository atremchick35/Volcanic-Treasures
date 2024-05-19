using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class LavaRing : MonoBehaviour, IBuffable
{
    [FormerlySerializedAs("Using time")] [SerializeField] private float usingTime;
    private Player _player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddBuff(GameObject player)
    {
        _player = player.GetComponent<Player>();
        _player.HasRingLava = true;
        GetComponent<Renderer>().enabled = false;
    }

    public void RemoveBuff()
    {
        _player.HasRingLava = false;
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddBuff(other.gameObject);
            Invoke(nameof(RemoveBuff), usingTime);
        }
    }
}
