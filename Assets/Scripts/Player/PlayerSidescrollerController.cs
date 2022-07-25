using UnityEngine;
using Input;

namespace Player
{
    public class PlayerSidescrollerController : MonoBehaviour
    {
        private static readonly int XVelocity = Animator.StringToHash("xVelocity");
        [SerializeField] private float _moveSpeed;
        private float _horizontalInput;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;
        private bool _facingRight = true;

        protected void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _transform = transform;
        }

        protected void Update()
        {
            _horizontalInput = InputManager.Instance.HorizontalInput();
        }

        protected void FixedUpdate()
        {
            Move(_horizontalInput, _moveSpeed);
        }

        private void Move(float horizontalInput, float speed)
        {
            var vel = new Vector2(horizontalInput * speed * 10f * Time.fixedDeltaTime, 0f);
            _rigidbody2D.velocity = vel; 
            _animator.SetFloat(XVelocity, Mathf.Abs(vel.x));
            
            switch (_facingRight)
            {
                case true when vel.x < 0:
                case false when vel.x > 0:
                    Flip();
                    break;
            }
        }

        private void Flip()
        {   
            //_spriteRenderer.flipX = !_spriteRenderer.flipX;
            _transform.Rotate(0f, 180f, 0f);
            _facingRight = !_facingRight;
        }
    }
}
