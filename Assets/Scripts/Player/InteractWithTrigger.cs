using Architecture;
using System;
using System.Collections;
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
            CheckForIndicatorAnimationStart();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            CheckForIndicatorAnimationEnd();
            _interactable = null;
        }
    }

    private void InteractInTrigger(InputAction.CallbackContext callbackContext)
    {
        if (_interactable == null) return;
        _interactable?.Interact();
        _indicatorAnimator.Play("Empty");
        _characterAnimator.SetTrigger(Interact);
        StartCoroutine(ResetIndicatorAnim());
    }


    private void CheckForIndicatorAnimationStart()
    {
        if (_interactable == null) return;
        if (_interactable is StartConversation)
            _indicatorAnimator.Play("start_talk");
        else
            _indicatorAnimator.Play("start_interact");
    }

    private void CheckForIndicatorAnimationEnd()
    {
        if (_interactable == null) return;
        if (_interactable is StartConversation)
            _indicatorAnimator.Play("stop_talk");
        else
            _indicatorAnimator.Play("stop_interact");
    }

    private IEnumerator ResetIndicatorAnim()
    {
        yield return null;
        WaitForSeconds waitTime = new WaitForSeconds(_characterAnimator.GetCurrentAnimatorClipInfo(0).Length);
        yield return waitTime;
        CheckForIndicatorAnimationStart();
    }
}
