using System;
using Architecture;
using UnityEngine;

namespace Puzzle
{
   public class PuzzleRoomExit : TileObject
   {
      [SerializeField] private Transform _target;
      [SerializeField] private Camera _targetRoomCamera;


      public void Exit()
      {
         PuzzleRoomManager.Instance.ActiveCamera.gameObject.SetActive(false);
         _targetRoomCamera.gameObject.SetActive(true);
         PuzzleRoomManager.Instance.ActiveCamera = _targetRoomCamera;

         if (PuzzleRoomManager.Instance.Player.TryGetComponent(out TopDownCharacter character))
         {
            character.transform.position = _target.position;
            character.UnregisterTileObject();
            character.RegisterTileObject();
         }
      }
   }
}
