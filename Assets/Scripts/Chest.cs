using Player_Scripts;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var key = other.gameObject.GetComponent<Player>().Key;
            if (key && key.CompareTag("ChestKey"))
            {
                _animator.SetTrigger("ChestOpen");
                key.Rigidbody.velocity = new Vector2(0, 0);
                Destroy(key.gameObject);
            }
        }
    }

    private void DropItem()
    {
        
    }
}
