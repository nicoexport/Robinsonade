using System;
using UnityEngine;

namespace Player
{
   public class TopDownCharacterBasic : MonoBehaviour, ITopDownCharacter
   {
      [SerializeField] float _moveTimeInSeconds = 0.2f;
      [SerializeField] float _moveRotation = 40f;
      [SerializeField] AnimationCurve _moveRotationCurve; 
      [SerializeField] float _collideTimeInSeconds = 0.2f;
      [SerializeField] float _collisionMovementInMeter = 0.05f;

      public void Move(Vector3 target, Vector2 direction, Action callback)
      {
         LeanTween.move(gameObject, target, _moveTimeInSeconds).setOnComplete(callback);
         LeanTween.rotateZ(gameObject,_moveRotation , _moveTimeInSeconds).setEase(_moveRotationCurve);
      }

      public void Collide(Vector2 direction, Action callback)
      {
         LeanTween.move(gameObject, transform.position + (Vector3)direction * _collisionMovementInMeter, _collideTimeInSeconds).setEasePunch().setOnComplete(callback);
      }
   }
}
