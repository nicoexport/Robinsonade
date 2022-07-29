#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StartSceneEditor : EditorWindow
{
    [MenuItem("CustomEditor/StartSceneEditor")]
    private static void Open()
    {
        GetWindow<StartSceneEditor>();
    }

    private void OnGUI()
    {
        EditorSceneManager.playModeStartScene = (SceneAsset)EditorGUILayout.ObjectField(new GUIContent("INIT_Scene"), EditorSceneManager.playModeStartScene, typeof(SceneAsset), false);
    }
}
#endif