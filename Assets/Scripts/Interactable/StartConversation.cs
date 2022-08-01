using UnityEngine;

public class StartConversation : MonoBehaviour, IInteractable
{
    private PuzzleLoader _puzzleLoader;

    private void Start()
    {
        if(TryGetComponent(out PuzzleLoader puzzleLoader))
            _puzzleLoader = puzzleLoader;
    }

    public void Interact()
    {
        Debug.Log("Conversation");
        if (_puzzleLoader)
            _puzzleLoader.SwitchToPuzzleScene();
    }
}
