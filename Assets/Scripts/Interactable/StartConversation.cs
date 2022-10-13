using UnityEngine;

public class StartConversation : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _sceneIndexToLoad;

    public void Interact()
    {
        SceneLoader.Instance.LoadScene(_sceneIndexToLoad);
    }
}
