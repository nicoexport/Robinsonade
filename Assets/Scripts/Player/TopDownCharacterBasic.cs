using System;
using Architecture;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
   public class TopDownCharacterBasic : TileObject, ITopDownCharacter
   {
      [SerializeField] float _moveTimeInSeconds = 0.2f;
      [SerializeField] float _moveRotation = 40f;
      [SerializeField] AnimationCurve _moveRotationCurve; 
      [SerializeField] float _collideTimeInSeconds = 0.2f;
      [SerializeField] float _collisionMovementInMeter = 0.05f;
      public UnityEvent OnCollide;
      public UnityEvent OnMove;

      public void Move(Vector3 target, Vector2 direction, Action callback)
      {
         OnMove.Invoke();
         UnregisterTileObject();
         LeanTween.move(gameObject, target, _moveTimeInSeconds).setOnComplete(()=>
         {
            callback();
            RegisterTileObject();
         });
         LeanTween.rotateZ(gameObject,_moveRotation , _moveTimeInSeconds).setEase(_moveRotationCurve);
      }

      public void Collide(Vector2 direction, Action callback)
      {
         OnCollide.Invoke();
         LeanTween.move(gameObject, transform.position + (Vector3)direction * _collisionMovementInMeter, _collideTimeInSeconds).setEasePunch().setOnComplete(callback);
      }
   }
}
