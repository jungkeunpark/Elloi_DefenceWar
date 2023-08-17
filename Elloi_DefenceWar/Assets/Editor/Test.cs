//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;

//public class Test : EditorWindow
//{
//    [MenuItem("Test/test")]
//    public static void open()
//    {
//        Test window = (Test)GetWindow(typeof(Test));
//        window.Show();
//    }

//    void OnGUI()
//    {
//        if (GUILayout.Button("½ÃÀÛ¾À"))
//        {
//            var pathOfFirstScene = EditorBuildSettings.scenes[7].path;
//            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);
//            EditorSceneManager.playModeStartScene = sceneAsset;
//            UnityEditor.EditorApplication.isPlaying = true;
//        }

//        if (GUILayout.Button("ÇöÀç¾À"))
//        {
//            EditorSceneManager.playModeStartScene = null;
//            UnityEditor.EditorApplication.isPlaying = true;
//        }
//    }
//}
