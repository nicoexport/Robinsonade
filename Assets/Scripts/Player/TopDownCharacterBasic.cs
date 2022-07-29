using System;
using Architecture;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
   public class TopDownCharacterBasic : TileObject, ITopDownCharacter
   {
      [SerializeField] private float _moveRotation = 40f;
      [SerializeField] private AnimationCurve _moveRotationCurve;
      [SerializeField] private float _collisionMovementInMeter = 0.05f;
      public UnityEvent OnCollide;
      public UnityEvent OnMove;

      public void Move(Vector3 target, Vector2 direction, float timeInSeconds, Action callback)
      {
         OnMove.Invoke();
         UnregisterTileObject();
         LeanTween.move(gameObject, target, timeInSeconds).setOnComplete(()=>
         {
            callback();
            RegisterTileObject();
         });
         LeanTween.rotateZ(gameObject,_moveRotation ,timeInSeconds).setEase(_moveRotationCurve);
      }

      public void Collide(Vector2 direction, float timeInSeconds, Action callback)
      {
         OnCollide.Invoke();
         LeanTween.move(gameObject, transform.position + (Vector3)direction * _collisionMovementInMeter, timeInSeconds).setEasePunch().setOnComplete(callback);
      }
      
      
   }
}
