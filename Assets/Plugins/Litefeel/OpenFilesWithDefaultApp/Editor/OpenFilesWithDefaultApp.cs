using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace litefeel.OpenFilesWithDefaultApp
{

    public static class OpenFilesWithDefaultApp
    {
        private const string PACKAGES = "Packages/";
        private const string ASSETS = "Assets/";

        [OnOpenAsset(0)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            var exts = PreferencesGUI.FileExts;
            if (exts.Length == 0) return false;

            // Packages/com.unity.render-pipelines.lightweight/Shaders/Unlit.shader
            string assetPath = AssetDatabase.GetAssetPath(instanceID);

            foreach (var ext in exts)
            {
                if (assetPath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                {
                    if (assetPath.StartsWith(ASSETS))
                        EditorUtility.OpenWithDefaultApp(assetPath);
                    else if (assetPath.StartsWith(PACKAGES))
                        OpenByPackages(assetPath);
                    return true;
                }
            }

            return false;
        }

        private static void OpenByPackages(string assetPath)
        {
#if UNITY_2018_1_OR_NEWER
            var request = Client.List(true);
            EditorApplication.CallbackFunction update = null;

            update = () =>
            {
                if (!request.IsCompleted) return;
                EditorApplication.update -= update;
                if (request.Status != StatusCode.Success) return;

                foreach (var entity in request.Result)
                {
                    // resolvedPath D:\work\MyProject\Library\PackageCache\com.unity.render-pipelines.lightweight@4.10.0-preview
                    if (assetPath.StartsWith(entity.assetPath))
                    {
                        var absPath = Path.Combine(entity.resolvedPath, GetPathWithoutPackage(assetPath));
                        EditorUtility.OpenWithDefaultApp(absPath);
                    }
                }
            };
            EditorApplication.update += update;
#endif
        }

        private static string GetPathWithoutPackage(string packagePath)
        {
            var index = packagePath.IndexOf('/', PACKAGES.Length);
            return packagePath.Substring(index + 1);
        }
    }
}