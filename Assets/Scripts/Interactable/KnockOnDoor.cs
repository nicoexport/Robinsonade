using UnityEngine;

public class KnockOnDoor : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Knock Knock");
    }
}
