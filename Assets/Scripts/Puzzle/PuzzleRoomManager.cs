using Architecture;
using UnityEngine;

namespace Puzzle
{
   public class PuzzleRoomManager : Singleton<PuzzleRoomManager>
   {
      public Camera ActiveCamera;
      public Transform Player;

      protected override void Awake()
      {
         base.Awake();
         ActiveCamera = Camera.main;
      }
   }
}
