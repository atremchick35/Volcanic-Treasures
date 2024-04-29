using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player_Scripts
{
    public class Movement : MonoBehaviour
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private bool _isContact;
        private bool _isLadder;
        [FormerlySerializedAs("Speed")] [SerializeField] public float speed;
        [FormerlySerializedAs("Jump Force")] [SerializeField] public float jumpForce;
        [FormerlySerializedAs("Climb Speed")] [SerializeField] public float climbSpeed;
    
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Подъём по лестнице (Зажим Spacebar)
            if (Input.GetButton("Jump") && _isLadder)
            {
                _rigidbody.velocity = new Vector2(0, climbSpeed);
                _rigidbody.velocity.Normalize();
            }
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
            //_animator.SetFloat("HorizontalMove", Math.Abs(horizontal));
        }

        //Проверка на сопрекосновение с полом
        private void OnCollisionEnter2D() => _isContact = true;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ladder"))
                _isLadder = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ladder"))
                _isLadder = false;
        }
        
    }
}
