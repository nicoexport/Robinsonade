using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public class EditorStartSceneManager
{
    static EditorStartSceneManager()
    {
        InitSceneSO initSceneSO = (InitSceneSO)AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Resources/SO_InitScene.asset", typeof(InitSceneSO));
        if(initSceneSO == null)
        {
            initSceneSO = ScriptableObject.CreateInstance<InitSceneSO>();
            AssetDatabase.CreateAsset(initSceneSO, "Assets/ScriptableObjects/Resources/SO_InitScene.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if (initSceneSO.sceneAsset)
        {
            EditorSceneManager.playModeStartScene = initSceneSO.sceneAsset;
        }
        else
        {
            Debug.Log("No InitScene set. Please set your startup scene in the InitSceneSo at Assets/ScriptableObjects/Resources");
        }
    }
}
