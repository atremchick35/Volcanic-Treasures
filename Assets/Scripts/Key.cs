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
        // Проверяет подобрал ли игрок ключ
        if (_active)
        {
            var direction = _player.position - transform.position + new Vector3(0, 0.5f);
            if (direction.magnitude >= epsilon)
                Rigidbody.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Конфликтующий объект - Игрок
        if (other.CompareTag("Player") && !other.GetComponent<Player>().Key)
        {
            other.GetComponent<Player>().Key = this;
            _active = true;
        } 
    }
}
