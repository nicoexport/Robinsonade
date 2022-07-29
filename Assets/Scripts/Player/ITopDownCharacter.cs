using System;
using Architecture;
using UnityEngine;

namespace Player
{
   public interface ITopDownCharacter
   {
      void Move(Vector3 target,Vector2 direction, float moveTimeInSeconds, Action callback);
      void Collide(Vector2 direction, Action callback);
   }
}
