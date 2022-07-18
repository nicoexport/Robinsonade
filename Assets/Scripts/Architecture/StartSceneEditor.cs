#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class StartSceneEditor : EditorWindow
{
    [MenuItem("CustomEditor/StartSceneEditor")]
    static void Open()
    {
        GetWindow<StartSceneEditor>();
    }

    private void OnGUI()
    {
        EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("INIT_Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);
    }
}
#endif