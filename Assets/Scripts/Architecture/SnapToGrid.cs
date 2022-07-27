using System;
using UnityEngine;

namespace Architecture
{
    public class SnapToGrid : MonoBehaviour
    {
        [SerializeField] bool _snapOnAwake = true;
        
        void Awake()
        {
            Snap();
        }

        void Snap()
        { 
            TileManager.Instance.SnapToGrid(gameObject);
        }
    }
}