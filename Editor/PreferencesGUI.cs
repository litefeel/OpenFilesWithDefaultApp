using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityScript.Lang;

namespace litefeel.OpenFilesWithDefaultApp
{

    public static class PreferencesGUI
    {
        private static readonly string[] Empty = new string[0];

        private const string KEY = "OpenFileWithDefaultApp_Exts";

        
        private static bool s_ArrCached = false;
        private static string[] s_FileExt;
        public static string[] FileExts
        {
            get
            {
                if (s_ArrCached && s_FileExt != null)
                    return s_FileExt;
                else
                {
                    s_ArrCached = true;
                    var str = FileExtsStr;
                    if (string.IsNullOrEmpty(str))
                        s_FileExt = Empty;
                    else
                    {
                        s_FileExt = str.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
                        for(var i = 0; i < s_FileExt.Length; ++i)
                        {
                            s_FileExt[i] = "." + s_FileExt[i];
                        }
                    }
                }
                return s_FileExt;
            }
        }

        private static string s_FileExtsStr;
        private static string FileExtsStr
        {
            get
            {
                if(s_FileExtsStr == null)
                    s_FileExtsStr = EditorPrefs.GetString(KEY, "");
                return s_FileExtsStr;
            }
            set
            {
                if(s_FileExtsStr != value && value != null)
                {
                    s_FileExtsStr = value;
                    EditorPrefs.SetString(KEY, s_FileExtsStr);
                    s_ArrCached = false;
                }
            }
        }

#if UNITY_2018_3_OR_NEWER
        //[PreferenceItem("Open Files With Default App")]
        private class MyPrefSettingsProvider : SettingsProvider
        {
            public MyPrefSettingsProvider(string path, SettingsScope scopes = SettingsScope.User)
            : base(path, scopes)
            { }

            public override void OnGUI(string searchContext)
            {
                PreferencesGUI.OnGUI();
            }
        }

        [SettingsProvider]
        static SettingsProvider NewPreferenceItem()
        {
            return new MyPrefSettingsProvider("Preferences/Open Files With Default App");
        }
#else
        [PreferenceItem("Open Files")]
#endif
        public static void OnGUI()
        {
            EditorGUILayout.LabelField("Specify the files will open with default application.");
            EditorGUILayout.LabelField("Separate the patterns with a space. e.g.(shader txt)");
            FileExtsStr = EditorGUILayout.TextField("File Extensions", FileExtsStr);
        }
    }
}