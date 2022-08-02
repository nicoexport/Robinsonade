using System;
using UnityEngine;
using UnityEngine.Events;

namespace Architecture
{
   public class PlusSign : TileObject
   {
      [SerializeField] private TileObject _inputIcon1;
      [SerializeField] public TileObject _inputIcon2;
      [SerializeField] private GameObject _combinationPrefab;
      [SerializeField] private GameObject _combineVFXPrefab;
      [SerializeField] private PlusSign _nextPlusSign;
      private readonly Vector3Int[] _neighbours = new Vector3Int[4];
      private bool _combined;
      private bool _setup = false;
      

      public UnityEvent<Vector3> OnCombine;

      protected void Start()
      {
         GetNeighbours();
      }
   

      protected void OnEnable()
      {
         TileManager.Instance.OnTileObjectsUpdate += CheckIcons;
      }

      protected void OnDisable()
      {
         TileManager.Instance.OnTileObjectsUpdate -= CheckIcons;
      }

      private void GetNeighbours()
      {
         var position = transform.position;
         _neighbours[0] = TileManager.Instance.GetNeighbour(position, Direction.North);
         _neighbours[1] = TileManager.Instance.GetNeighbour(position, Direction.East);
         _neighbours[2] = TileManager.Instance.GetNeighbour(position, Direction.South);
         _neighbours[3] = TileManager.Instance.GetNeighbour(position, Direction.West);
         _setup = true;
      }

      private void CheckIcons()
      {
         if (_combined || !_setup)
            return;
         var north = TileManager.Instance.GetTileObject(_neighbours[0]);
         var east = TileManager.Instance.GetTileObject(_neighbours[1]);
         var south = TileManager.Instance.GetTileObject(_neighbours[2]);
         var west = TileManager.Instance.GetTileObject(_neighbours[3]);

         if (north != null && south != null)
         {
            if ((north == _inputIcon1 && south == _inputIcon2) || (north == _inputIcon2 && south == _inputIcon1))
            {
               _combined = true;
               Combine();
            }
         }

         if (west != null && east != null)
         {
            if ((west == _inputIcon1 && east == _inputIcon2) || (west == _inputIcon2 && east == _inputIcon1))
            {
               _combined = true;
               Combine();
            }
         }
      }

      private void Combine()
      {
         var position = transform.position;
         OnCombine?.Invoke(position);
        _inputIcon1.Delete();
        _inputIcon2.Delete();
        UnregisterTileObject();
        var comb = Instantiate(_combinationPrefab, position, Quaternion.identity);
        if (_nextPlusSign != null)
        {
           var tileobj = comb.GetComponent<TileObject>();
           _nextPlusSign._inputIcon2 = tileobj;
        }
        Instantiate(_combineVFXPrefab, position, Quaternion.identity);
        Destroy(gameObject);
      }
   }
}
