using UnityEngine;
using TCG.Debug;

namespace TCG.Utils
{
    /// <summary>
    /// Collection of utility and extension functions for game objects 
    /// </summary>
    public static class GameObjectUtils
    {
        /// <summary>
        /// Will toggle a GameObject on/off based on its active self 
        /// </summary>
        public static void InvertActiveSelf(this GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
        
        /// <summary>
        /// Extension to find a component on a game object or throw an assert
        /// </summary>
        public static void FindComponentOrAssert<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            ChannelLogger.Instance.Assert(component != null, $"Could not find component of type {typeof(T)} on {gameObject.name}");
        }
    }
}