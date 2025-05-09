﻿using JetBrains.Annotations;
using UnityEngine;

namespace Utilities
{
    public abstract class Singleton<T> : Singleton where T : MonoBehaviour
    {
        #region Fields

        [CanBeNull]
        private static T _instance;

        [NotNull]
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new();

        [SerializeField]
        protected bool _persistent;

        #endregion

        #region Properties

        [NotNull]
        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (_instance != null)
                        return _instance;
                    var instances = FindObjectsOfType<T>(true);
                    var count     = instances.Length;
                    if (count > 0)
                    {
                        if (count == 1)
                            return _instance = instances[0];
                        Debug.LogWarning(
                            $"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                        for (var i = 1; i < instances.Length; i++)
                            Destroy(instances[i]);
                        return _instance = instances[0];
                    }

                    Debug.Log($"[{nameof(Singleton)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
                    return _instance = new GameObject($"({nameof(Singleton)}){typeof(T)}")
                        .AddComponent<T>();
                }
            }
        }
        
        public static bool IsInitialized => _instance != null;

        #endregion

        #region Methods

        private void Awake()
        {
            if (_persistent)
                DontDestroyOnLoad(gameObject);
            OnAwake();
        }

        private void OnDestroy()
        {
            _instance = null;
        }

        private void OnDisable()
        {
            _instance = null;
        }

        protected virtual void OnAwake()
        {
            var instances = FindObjectsOfType<T>(true);
            var count     = instances.Length;
            if (count > 1)
            {
                Debug.LogWarning(
                    $"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                for (var i = 1; i < instances.Length; i++)
                    Destroy(instances[i].gameObject);
            }
        }

        #endregion
    }

    public abstract class Singleton : MonoBehaviour {
    }
}