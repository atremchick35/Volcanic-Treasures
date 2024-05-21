using System.Collections.Generic;
using Buffs;
using Interfaces;
using Player_Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private List<ILootable> _loot;

    // Инициализация списка выпадаемых предметов из сундука
    private void Awake()
    {
        _loot = new()
        {
            gameObject.AddComponent<Boots>(),
            gameObject.AddComponent<Helmet>(),
            gameObject.AddComponent<LavaRing>(),
            gameObject.AddComponent<Coin>(),
            gameObject.AddComponent<Diamond>()
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
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

    // Выдать игроку предмет
    private void DropItem()
    {
        var dropped = _loot[Random.Range(0, _loot.Count)];
        dropped.GivePlayer();
    }
}
