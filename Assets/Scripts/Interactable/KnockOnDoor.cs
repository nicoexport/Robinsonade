using UnityEngine;

public class KnockOnDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _sceneIndexToLoad;

    public void Interact()
    {
        SceneLoader.Instance.LoadScene(_sceneIndexToLoad);
    }
}
