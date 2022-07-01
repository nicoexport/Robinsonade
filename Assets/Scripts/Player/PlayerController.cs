using System;
using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
   public class PlayerController : MonoBehaviour
   {
      [SerializeField] private float _moveSpeed;
      private float _horizontalInput;
      private Rigidbody2D _rigidbody2D;
      
      
      
      protected void Awake()
      {
         _rigidbody2D = GetComponent<Rigidbody2D>();
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
         Debug.Log(horizontalInput);
         _rigidbody2D.velocity = new Vector2(horizontalInput * speed * 10f * Time.fixedDeltaTime, 0f);
      }
   }
}
