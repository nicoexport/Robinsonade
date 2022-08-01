using System;
using UnityEngine;

namespace Architecture
{
    public class SnapToGrid : MonoBehaviour
    {
        [SerializeField] private bool _snapOnAwake = true;

        private void Awake()
        {
            if(_snapOnAwake)
                Snap();
        }

        private void Snap()
        { 
            TileManager.Instance.SnapToGrid(gameObject);
        }
    }
}