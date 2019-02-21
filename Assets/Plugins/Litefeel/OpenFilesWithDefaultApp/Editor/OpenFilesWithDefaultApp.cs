using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace litefeel.OpenFilesWithDefaultApp
{

    public static class OpenFilesWithDefaultApp
    {

        [OnOpenAsset(0)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            var exts = PreferencesGUI.FileExts;
            if (exts.Length == 0) return false;

            string assetPath = AssetDatabase.GetAssetPath(instanceID);

            foreach(var ext in exts)
            {
                if(assetPath.EndsWith(ext, StringComparison.OrdinalIgnoreCase))
                {
                    EditorUtility.OpenWithDefaultApp(assetPath);
                    return true;
                }
            }
            
            return false;
        }
        
    }
}