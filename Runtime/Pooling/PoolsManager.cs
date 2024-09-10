using System.Collections.Generic;
using UnityEngine;
using System;

namespace com.trashpandaboy.instances.Pooling
{
    public class PoolsManager : Service<PoolsManager>
    {
        /// <summary>
        /// Prefab of the ObjectPool
        /// </summary>
        [SerializeField] GameObject _objectToolPrefab;

        protected override void Awake()
        {
            _pools = new Dictionary<GameObject, ObjectPool>();
            base.Awake();
        }

        /// <summary>
        /// Contains all references to ObjectPools added
        /// </summary>
        Dictionary<GameObject, ObjectPool> _pools;

        /// <summary>
        /// Get the ObjectPool of the given GameObject
        /// </summary>
        /// <param name="_prefabOfPool"></param>
        /// <returns></returns>
        public ObjectPool GetObjectPool(GameObject _prefabOfPool)
        {
            if (!_pools.ContainsKey(_prefabOfPool))
            {
                var goPool = Instantiate(_objectToolPrefab, transform.position, Quaternion.identity);
                var objectPoolInstance = goPool.GetComponent<ObjectPool>();
                objectPoolInstance.Setup(_prefabOfPool);
                _pools[_prefabOfPool] = objectPoolInstance;
            }

            return _pools[_prefabOfPool];
        }

        /// <summary>
        /// Get the ObjectPool of the given type
        /// </summary>
        /// <param name="gameobjectType"></param>
        /// <returns></returns>
        public ObjectPool GetObjectPoolOfType(Type gameobjectType)
        {
            foreach (var pool in _pools)
            {
                if (pool.Key.GetType() == gameobjectType)
                    return pool.Value;
            }
            return null;
        }

        /// <summary>
        /// Release the given GameObject to the correct ObjectPool
        /// </summary>
        /// <param name="objToRelease"></param>
        public void ReleaseGameobject(GameObject objToRelease)
        {
            foreach (var kvp in _pools)
            {
                if (objToRelease.GetType() == kvp.Key.GetType())
                {
                    kvp.Value.ReleaseGameobject(objToRelease);
                    break;
                }
            }
        }

    }
}