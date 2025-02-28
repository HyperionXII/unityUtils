using System;
using UnityEditor;
using UnityEngine;

namespace TCG.Build
{
    
    [CreateAssetMenu(fileName = "BuildSettings", menuName = "Build/Build Settings")]
    public class BuildSettings : ScriptableObject
    {
        private const string k_resourcesPath = "BuildSettings";

        [SerializeField] private string _versionNumber = "0.0.1";
        [SerializeField] private string _buildPath = "../Builds";
        [SerializeField] private string[] _scenePaths;

        [SerializeField] private BuildOptions _devOptions;
        [SerializeField] private BuildOptions _releaseOptions;

        public string VersionNumber => _versionNumber;
        public string BuildPath => _buildPath;
        public string[] ScenePaths => _scenePaths;
        
        public BuildOptions DevOptions => _devOptions;
        public BuildOptions ReleaseOptions => _releaseOptions;

        public static BuildSettings LoadFromResources()
        {
            var settings = Resources.Load<BuildSettings>(k_resourcesPath);

            return settings;
        }


#if UNITY_EDITOR
        public void OnValidate()
        {
            if (_buildPath.EndsWith('/') || _buildPath.EndsWith('\\'))
            {
                _buildPath = _buildPath.Substring(0, _buildPath.Length - 1);
            }
        }
#endif
    }
}