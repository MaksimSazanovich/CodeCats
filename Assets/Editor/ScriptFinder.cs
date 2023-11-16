// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RimuruDev.Codebase.Utilities.Editor.ScriptFinder
{
    public sealed class ScriptFinder : EditorWindow
    {
        private int totalScriptsFound;
        private string[] scriptsInFolder;
        private bool searchAllSubFolders = true;

        private static string myScriptPath =>
            Path.Combine(Application.dataPath + @"/Scrpts");

        private static string projectScriptPath =>
            Application.dataPath;

        [MenuItem("Rimuru Dev Tools/Script Finder")]
        public static void ShowWindow()
        {
            var window = (ScriptFinder)GetWindow(typeof(ScriptFinder));

            window.titleContent.text = "Script Finder";
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Script Search", EditorStyles.boldLabel);

            searchAllSubFolders = EditorGUILayout.Toggle("Search In All Subfolders", searchAllSubFolders);

            if (GUILayout.Button("Find My Scripts") && !string.IsNullOrEmpty(myScriptPath))
                FindScripts(myScriptPath);

            if (GUILayout.Button("Find Project Scripts") && !string.IsNullOrEmpty(projectScriptPath))
                FindScripts(projectScriptPath);
        }

        private void FindScripts(string scriptPath)
        {
            scriptsInFolder = Directory.GetFiles(scriptPath, "*.cs",
                searchAllSubFolders
                    ? SearchOption.AllDirectories
                    : SearchOption.TopDirectoryOnly);

            totalScriptsFound = scriptsInFolder.Length;

            Debug.Log($"<color=magenta>Scripts Found:</color> <color=yellow>{totalScriptsFound}</color>");
        }
    }
}
#endif