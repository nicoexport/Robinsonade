using System.Collections;
using UnityEngine;

public class KnockOnDoor : MonoBehaviour, IInteractable
{
    [SerializeField]
    private int _sceneIndexToLoad;
    [SerializeField]
    private bool _canEnter;
    [Space]
    [Header("Visuals")]
    [SerializeField]
    public bool playAnimationOnAwake;

    private Animator _doorReactionAnimator;

    private void Awake()
    {
        _doorReactionAnimator = GetComponent<Animator>();

        if (playAnimationOnAwake)
        {
            _doorReactionAnimator.Play("close_door");
        }
    }

    public void Interact()
    {
        if (_canEnter)
        {
            SceneLoader.Instance.LoadScene(_sceneIndexToLoad);
            _doorReactionAnimator.Play("open_door");
        }
        else
        {
            _doorReactionAnimator.Play("no_entry");
            StartCoroutine(ResetDoorAnimation());
        }
    }

    private IEnumerator ResetDoorAnimation()
    {
        yield return null;
        WaitForSeconds waitTime = new WaitForSeconds(_doorReactionAnimator.GetCurrentAnimatorClipInfo(0).Length);
        yield return waitTime;
        _doorReactionAnimator.Play("Empty");
    }
}
