using Interfaces;
using Player_Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class Key : MonoBehaviour, IInteractable
{
    private bool _active;
    private Player _player;
    public Rigidbody2D Rigidbody { get; private set; }

    [FormerlySerializedAs("Epsilon")] [SerializeField] 
    private double epsilon;
    
    [FormerlySerializedAs("Speed")] [SerializeField] 
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
            var direction = _player.transform.position - transform.position + new Vector3(0, 0.5f);
            if (direction.magnitude >= epsilon)
                Rigidbody.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Конфликтующий объект - Игрок
        if (other.CompareTag("Player") && !_player.Key)
        {
            _player.Key = this;
            _active = true;
        } 
    }
}
