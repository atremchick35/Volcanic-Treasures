using System;
using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Key : MonoBehaviour, IInteractable
{
    private bool _active;
    private Transform _player;
    [NonSerialized] public Rigidbody2D Rigidbody;
    [FormerlySerializedAs("Epsilon")] [SerializeField] private double epsilon;
    [FormerlySerializedAs("Speed")] [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (_active) // Проверяет подобрал ли игрок ключ
        {
            var direction = _player.position - transform.position + new Vector3(0, 1);
            if (direction.magnitude >= epsilon)
                Rigidbody.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<Player>().Key) // Конфликтующий объект - Игрок
        {
            other.GetComponent<Player>().Key = this;
            _active = true;
        } 
    }
}
