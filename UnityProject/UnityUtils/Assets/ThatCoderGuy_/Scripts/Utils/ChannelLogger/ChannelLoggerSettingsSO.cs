using System;
using UnityEngine;

namespace TCG.Debug
{
    [CreateAssetMenu( fileName = "ChannelLoggerSettings", menuName = "ThatCoderGuy_/Channel Logger/Channel Logger Settings")]
    public class ChannelLoggerSettingsSO : ScriptableObject
    {
        private const string k_resourcePath = "ChannelLoggerSettings";

        [SerializeField] private ChannelLoggerSettings _settings;
        public ChannelLoggerSettings Settings => _settings;
        
        public static ChannelLoggerSettings LoadFromResources()
        {
            var settings = Resources.Load<ChannelLoggerSettingsSO>(k_resourcePath);
            UnityEngine.Debug.Assert(settings != null, $"Cannot load ChannelLoggerSettings from Resources: {k_resourcePath}");
            
            return settings.Settings;
        }
    }
    
    [Serializable]
    public class ChannelLoggerSettings
    {
        [SerializeField] private LogChannels _activeChannels;

        public LogChannels ActiveChannels => _activeChannels;
    }
}