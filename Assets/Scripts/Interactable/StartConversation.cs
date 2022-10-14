using UnityEngine;
using UnityEngine.SceneManagement;

public class StartConversation : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _sceneIndexToLoad;

    public void Interact()
    {
        SceneLoader.Instance.last_RealWorldScene_Index = SceneManager.GetActiveScene().buildIndex;
        SceneLoader.Instance.LoadScene(_sceneIndexToLoad);
    }
}
