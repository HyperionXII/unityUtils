using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TCG.Build
{
    /// <summary>
    /// 
    /// </summary>
    public static class BuildTools
    {
        private const string k_buildToolsBasePath = "BuildTools/";
        


        [MenuItem(k_buildToolsBasePath + "Build Windows")]
        public static void BuildWindowsRelease()
        {
            var settings = BuildSettings.LoadFromResources();
            Debug.Assert(settings != null, "No build settings found.");
            
            BuildStandalone64(false, settings);
        }
        
        [MenuItem(k_buildToolsBasePath + "Build Windows Debug")]
        public static void BuildWindowsDebug()
        {
            var settings = BuildSettings.LoadFromResources();
            Debug.Assert(settings != null, "No build settings found.");
            
            BuildStandalone64(true, settings);
        }
        
        private static void BuildStandalone64(bool isDev, BuildSettings buildSettings)
        {
            Debug.Log("Building Standalone 64");

            BuildPlayerOptions buildPlayerOptions = new()
            {
                target = BuildTarget.StandaloneWindows,
                options = isDev ? buildSettings.DevOptions : buildSettings.ReleaseOptions,
                locationPathName = $"{buildSettings.BuildPath}/",
            };

            if (isDev)
            {
                buildPlayerOptions.options |= BuildOptions.Development;
            }
            
            BuildWithOptions(buildPlayerOptions);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildPlayerOptions"></param>
        private static void BuildWithOptions(BuildPlayerOptions buildPlayerOptions)
        {
            //-TODO
        }
    }
}