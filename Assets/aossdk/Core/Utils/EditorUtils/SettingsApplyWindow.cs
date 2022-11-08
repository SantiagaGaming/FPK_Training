#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace AosSdk.Core.Utils.EditorUtils
{
    [InitializeOnLoad]
    public class SettingsApplyWindow : EditorWindow
    {
        private const string PackagesManifestPath = @"Packages\manifest.json";
        private bool _isPackagesInstalled;
    
        private static readonly Dictionary<string, string> PackagesToAdd = new Dictionary<string, string>();
    
        static SettingsApplyWindow()
        {
            if (PlayerPrefs.HasKey($"{PlayerSettings.productName}AosSdkPluginsInstalled"))
            {
                return;
            }
        
            //ShowWindow();
        }

        [MenuItem("AOS/Packages installation window")]
        private static void ShowWindow()
        {
            PackagesToAdd.Add("com.unity.xr.interaction.toolkit", "2.0.0-pre.7");
            PackagesToAdd.Add("com.unity.xr.management", "4.2.1");
            PackagesToAdd.Add("com.unity.xr.openxr", "1.4.2");
        
            var window = GetWindow<SettingsApplyWindow>(true);
            window.minSize = new Vector2(400, 200);
            window.maxSize = new Vector2(400, 200);
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Install required packages", GUILayout.Height(30)))
            {
                try
                {
                    var currentlyInstalledPackages = JsonConvert.DeserializeObject<DependencyList>(File.ReadAllText(PackagesManifestPath));

                    if (currentlyInstalledPackages == null)
                    {
                        Debug.LogError($"Can't deserialize {PackagesManifestPath}");
                        return;
                    }

                    foreach (var package in PackagesToAdd.Where(package => !currentlyInstalledPackages.dependencies.ContainsKey(package.Key)))
                    {
                        currentlyInstalledPackages.dependencies.Add(package.Key, package.Value);
                    }

                    File.WriteAllText(PackagesManifestPath, JsonConvert.SerializeObject(currentlyInstalledPackages));

                    _isPackagesInstalled = true;
                    PlayerPrefs.SetInt($"{PlayerSettings.productName}AosSdkPluginsInstalled", 1);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                    return;
                }
            }

            if (_isPackagesInstalled) 
            {
                EditorGUILayout.Separator();
            
                if (GUILayout.Button("Restart Unity", GUILayout.Height(30)))
                {
                    EditorApplication.OpenProject(Directory.GetCurrentDirectory());
                }
            }

            EditorGUILayout.EndVertical();
        }
    }

    [Serializable]
    public class DependencyList
    {
        public Dictionary<string, string> dependencies;
    }
}
#endif