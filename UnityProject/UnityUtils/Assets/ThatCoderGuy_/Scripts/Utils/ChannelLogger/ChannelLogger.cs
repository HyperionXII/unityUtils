using System.Collections.Generic;
using UnityEngine;
using TCG.Utils;

namespace TCG.Debug
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelLogger : MonoSingleton<ChannelLogger>
    {
        [SerializeField] private int _logStackSize = 20;

        private ChannelLoggerSettings _channelLoggerSettings;

        private Queue<string> _logStack = new();

        public void Initialise()
        {
            _channelLoggerSettings = ChannelLoggerSettingsSO.LoadFromResources();
        }

#region Logging

        public void Log(string message, LogChannels channel = LogChannels.Default)
        {
            if ((_channelLoggerSettings.ActiveChannels & channel) > 0)
            {
                UnityEngine.Debug.Log(message);
                AddToLogStack($"[Log] {message}");
            }
        }
        
        public void LogWarning(string message, LogChannels channel = LogChannels.Default)
        {
            if ((_channelLoggerSettings.ActiveChannels & channel) > 0)
            {
                UnityEngine.Debug.LogWarning(message);
                AddToLogStack($"[WARNING] {message}");
            }
        }
        
        public void LogError(string message, LogChannels channel = LogChannels.Default)
        {
            if ((_channelLoggerSettings.ActiveChannels & channel) > 0)
            {
                UnityEngine.Debug.LogError(message);
                AddToLogStack($"[ERROR] {message}");
            }
        }
        
        public void Assert(bool condition, string message, LogChannels channel = LogChannels.Default)
        {
            if ((_channelLoggerSettings.ActiveChannels & channel) > 0)
            {
                if (!condition)
                {
                    UnityEngine.Debug.LogAssertion(message);
                    AddToLogStack($"[ASSERT] {message}");
                }
            }
        }
#endregion

#region Stack Handling

        public string[] LogStack => _logStack.ToArray();

        private void ClearLogStack()
        {
            _logStack.Clear();
        }
        
        private void AddToLogStack(string message)
        {
            if (_logStack.Count >= _logStackSize)
            {
                _logStack.Dequeue();
                _logStack.Enqueue(message);
            }
        }
        
#endregion
    }
}