using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

public class Boulder : MonoBehaviour, ITrapable
{
    [FormerlySerializedAs("GravityForce")] [SerializeField] private float gravityForce;
    [FormerlySerializedAs("Life span")] [SerializeField] private float time;

    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _rigidbody.gravityScale = gravityForce;
            Destroy(gameObject, time);
        }
    }

    public void KillPlayer(){}
}
