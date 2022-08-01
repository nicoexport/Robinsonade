using UnityEngine;

public class StartConversation : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Conversation");
        GetComponent<SwitchToPuzzleScene>().StartPuzzle();
    }
}
