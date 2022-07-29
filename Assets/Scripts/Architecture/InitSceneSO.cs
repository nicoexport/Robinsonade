using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_InitScene", menuName = "Scriptable Objects/InitScene", order = 0)]

public class InitSceneSO : ScriptableObject
{
    public SceneAsset sceneAsset;
}
