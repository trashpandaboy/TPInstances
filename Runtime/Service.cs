using UnityEngine;

namespace com.trashpandaboy.instances
{
    /// <summary>
    /// Base class for services that are used to manage the game.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Service<T> : MonoBehaviour where T : Service<T>
    {
        /// <summary>
        /// If true, the service will be a singleton.
        /// </summary>
        [SerializeField]
        bool UseSingleton = false;

        /// <summary>
        /// The instance of the service.
        /// </summary>
        public static T Instance => _instance;
        protected static T _instance;

        protected virtual void Awake()
        {
            if(UseSingleton)
            {
                if(_instance != null && _instance != (T)this)
                {
                    Destroy(this);
                }
                else
                {
                    _instance = (T)this;
                }
            }
        }
    }
}
