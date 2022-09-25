using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Pooling
{
    public class GameObjectPool : IDisposable
    {
        readonly Transform _parent;
        readonly IObjectPool<GameObject> _pool;
        readonly GameObject _prefab;
        public readonly int capacity;

        public GameObjectPool(Transform parent, GameObject prefab, int capacity)
        {
            Assert.IsTrue(parent);
            _prefab = prefab;
            _parent = parent;
            this.capacity = capacity;
            _pool = new LinkedPool<GameObject>(
                InstantiateInstance,
                EnableInstance,
                DisableInstance,
                DestroyInstance,
                false,
                capacity
            );
        }

        public GameObjectPool(Transform parent, int capacity)
        {
            Assert.IsTrue(parent);
            _parent = parent;
            this.capacity = capacity;
            _pool = new LinkedPool<GameObject>(
                CreateInstance,
                EnableInstance,
                DisableInstance,
                DestroyInstance,
                false,
                capacity
            );
        }

        public void Dispose()
        {
            _pool.Clear();
        }

        public event Action<GameObject> onInstantiate;

        void DestroyInstance(GameObject obj)
        {
            Object.Destroy(obj);
        }

        void DisableInstance(GameObject obj)
        {
            obj.SetActive(false);
        }

        void EnableInstance(GameObject obj)
        {
            obj.SetActive(true);
        }

        GameObject InstantiateInstance()
        {
            var obj = Object.Instantiate(_prefab, _parent);
            onInstantiate?.Invoke(obj);
            return obj;
        }

        GameObject CreateInstance()
        {
            var obj = new GameObject();
            obj.transform.parent = _parent;
            onInstantiate?.Invoke(obj);
            return obj;
        }

        public GameObject Request()
        {
            return _pool.Get();
        }

        public void Return(GameObject obj)
        {
            _pool.Release(obj);
        }
    }
}