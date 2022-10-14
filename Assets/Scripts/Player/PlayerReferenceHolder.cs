using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceHolder : MonoBehaviour
{
    [SerializeField]
    private Animator _characterAnimator;
    [SerializeField]
    private Animator _indicatorAnimator;
    [SerializeField]
    private Transform _indicatorVisualsTransform;

    public Animator CharacterAnimator { get => _characterAnimator; private set => _characterAnimator = value; }
    public Animator IndicatorAnimator { get => _indicatorAnimator; private set => _indicatorAnimator = value; }
    public Transform IndicatorVisualsTransform { get => _indicatorVisualsTransform; private set => _indicatorVisualsTransform = value; }
}
