using Interfaces;
using Player_Scripts;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public Rigidbody2D Rigidbody { get; private set; }
    
    private bool _active;
    private Player _player;

    [SerializeField] private double epsilon;
    [SerializeField] private float speed;
    
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        // Проверяет подобрал ли игрок ключ, а затем заставляет ключ двигаться за игроком
        if (_active)
        {
            var direction = _player.transform.position - transform.position + new Vector3(0, 1f);
            if (direction.magnitude >= epsilon)
                Rigidbody.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Если контактирующий объект игрок
        if (other.CompareTag("Player") && !_player.Key)
        {
            _player.Key = this;
            _active = true;
        } 
    }
}
