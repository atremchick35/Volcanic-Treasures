using System.Collections.Generic;
using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private readonly List<ILootable> _loot = new();
    
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
                DropItem();
            }
        }
    }

    private void DropItem()
    {
        var dropped = _loot[Random.Range(0, _loot.Count - 1)];
        //Какой то метод хз пока что
    }
}
