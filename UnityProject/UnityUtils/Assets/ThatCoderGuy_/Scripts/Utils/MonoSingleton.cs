using UnityEngine;

namespace TCG.Utils
{
    /// <summary>
    /// Singleton class for MonoBehaviour scripts 
    /// </summary>
    /// <typeparam name="T">Type of the singleton</typeparam>
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance => _instance;

        
#region Unity Events 
        private void Awake()
        {
            OnAwake();
        }
#endregion

        /// <summary>
        /// Use this rather than the Awake function
        /// </summary>
        public virtual void OnAwake()
        {
            //--Use this rather than the awake function
        }
    }
}