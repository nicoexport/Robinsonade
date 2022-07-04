using UnityEngine;
using Input;

public class InteractWithTrigger : MonoBehaviour
{
    private IInteractable _interactable;

    private void Start()
    {
        InputManager.Instance.InteractEvent.AddListener(InteractInTrigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _interactable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _interactable = null;
        }
    }

    private void InteractInTrigger()
    {
        _interactable?.Interact();
    }
}
