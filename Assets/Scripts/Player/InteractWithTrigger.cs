using Architecture;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractWithTrigger : MonoBehaviour
{
    private static readonly int Interact = Animator.StringToHash("Interact");
    private IInteractable _interactable;
    private Animator _characterAnimator;
    private Animator _indicatorAnimator;

    private void Awake()
    {
        _characterAnimator = GetComponent<PlayerReferenceHolder>().CharacterAnimator;
        _indicatorAnimator = GetComponent<PlayerReferenceHolder>().IndicatorAnimator;
    }

    private void OnEnable()
    {
        InputManager.Instance.InteractEvent += InteractInTrigger;
    }

    private void OnDisable()
    {
        InputManager.Instance.InteractEvent -= InteractInTrigger;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            _interactable = interactable;
            if (_interactable is StartConversation)
                _indicatorAnimator.Play("start_talk");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            if (_interactable is StartConversation)
                _indicatorAnimator.Play("stop_talk");
            _interactable = null;
        }
    }

    private void InteractInTrigger(InputAction.CallbackContext callbackContext)
    {
        if (_interactable == null) return;
        _interactable?.Interact();
        _characterAnimator.SetTrigger(Interact);
    }
}
