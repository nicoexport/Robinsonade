using System;
using UnityEngine;
using Input;
using UnityEngine.InputSystem;

public class InteractWithTrigger : MonoBehaviour
{
    private static readonly int Interact = Animator.StringToHash("Interact");
    private IInteractable _interactable;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        InputManager.InteractEvent += InteractInTrigger;
    }

    private void OnDisable()
    { 
        InputManager.InteractEvent -= InteractInTrigger;
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

    private void InteractInTrigger(InputAction.CallbackContext callbackContext)
    {
        if (_interactable == null) return;
        _interactable?.Interact();
        _animator.SetTrigger(Interact);
    }
}
