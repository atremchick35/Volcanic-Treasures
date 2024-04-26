using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _isContact;
    [[FormerlySerializedAs("Speed")] [SerializeField] public float speed;
    [FormerlySerializedAs("Jump Force")] [SerializeField] private float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Вертикальное управление (Spacebar)
        if (Input.GetButton("Jump") && _isContact)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce));
            _isContact = false;
        }
    }

    private void FixedUpdate()
    {
        // Горизонтальное управление (A / D)
        var horizontal = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(horizontal * speed, _rigidbody.velocity.y);
        _rigidbody.velocity.Normalize();
    }

    //Проверка на сопрекосновение с полом
    private void OnCollisionEnter2D() => _isContact = true;
}
