using System;
using UnityEngine;

namespace Player_Scripts
{
    // Данный скрипт висит на игроке и отвечает за управление им
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer sprite;
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform ladderCheck;
        
        [SerializeField] private LayerMask slopeLayer;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private LayerMask ladderLayer;
        
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;

        private bool _isLadder;
        
        public void Freeze()
        {
            speed = 0;
            jumpForce = 0;
        }
        
        public void SetSpeed(float acceleration) => speed *= acceleration;

        public void ResetSpeed(float acceleration)
        {
            if (Math.Abs(acceleration) < float.Epsilon)
                throw new DivideByZeroException();
            
            speed /= acceleration;
        }
        
        public void SetJumpForce(float jumpCoefficient) => jumpForce *= jumpCoefficient;
        
        public void ResetJumpForce(float jumpCoefficient)
        { 
            if (Math.Abs(jumpCoefficient) < float.Epsilon)
                throw new DivideByZeroException();
            
            jumpForce /= jumpCoefficient;
        }
        
        private void Update()
        {
            // Подъём по лестнице (Зажим Spacebar)
            if (Input.GetButton("Jump") && IsOnLadder())
                rb.velocity = new Vector2(0, Fields.Player.ClimbSpeed);

            // Прыжок (Разовое нажатие Spacebar)
            if (Input.GetButton("Jump"))
            {
                if (IsGrounded())
                    rb.velocity = new Vector2(0, jumpForce);
                if (IsOnSlope())
                    rb.velocity = new Vector2(0, jumpForce + Fields.Player.SlopeJumpIncrease);
            }
        }

        private void FixedUpdate()
        {
            // Горизонтальное управление (A / D + leftArrow / rightArrow)
            var horizontal = Input.GetAxis(Fields.Player.HorizontalAxisName);
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                
            // Анимация движения при беге
            animator.SetFloat(Fields.AnimationState.PlayerMove, Math.Abs(horizontal));
            sprite.flipX = horizontal < 0;
        }
        
        // Проверка на сопрекосновение с полом
        private bool IsGrounded() => 
            Physics2D.OverlapCircle(groundCheck.position, Fields.Player.GroundCheckRadius, groundLayer);

        // Проверка на нахождение на лестнице
        private bool IsOnLadder() => 
            Physics2D.OverlapCircle(ladderCheck.position, Fields.Player.LadderCheckRadius, ladderLayer);
        
        // Проверка на нахождение на наклонной поверхности
        private bool IsOnSlope() => 
            Physics2D.OverlapCircle(groundCheck.position, Fields.Player.SlopeCheckRadius, slopeLayer);
    }
}
