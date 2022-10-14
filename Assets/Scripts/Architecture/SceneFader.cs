using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [SerializeField]
    private SceneFaderUI _sceneFaderUI_prefab;

    private SceneFaderUI _currentSceneFaderUI;
    private Animator _sceneFaderAnimator;

    private void Awake()
    {
        _currentSceneFaderUI = Instantiate(_sceneFaderUI_prefab);
        _sceneFaderAnimator = _currentSceneFaderUI.GetComponent<Animator>();
    }

    public float FadeOut()
    {
        _sceneFaderAnimator.Play("FadeOut");
        return _sceneFaderAnimator.GetCurrentAnimatorStateInfo(0).length;
    }

    public float FadeIn()
    {
        _sceneFaderAnimator.Play("FadeIn");
        return _sceneFaderAnimator.GetCurrentAnimatorStateInfo(0).length;
    }
}
