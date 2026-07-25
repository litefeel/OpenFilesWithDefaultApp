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

#if UNITY_6000_5_OR_NEWER
        [OnOpenAsset(0)]
        public static bool OnOpenAsset(EntityId assetId, int line)
#else
        [OnOpenAsset(0)]
        public static bool OnOpenAsset(int assetId, int line)
#endif
        {
            var exts = PreferencesGUI.FileExts;
            if (exts.Length == 0) return false;

            // Packages/com.unity.render-pipelines.lightweight/Shaders/Unlit.shader
            string assetPath = AssetDatabase.GetAssetPath(assetId);

            foreach (var ext in exts)
            {
                if (assetPath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                {
                    var fullPath = Path.GetFullPath(assetPath);
                    EditorUtility.OpenWithDefaultApp(fullPath);
                    return true;
                }
            }

            return false;
        }
    }
}
