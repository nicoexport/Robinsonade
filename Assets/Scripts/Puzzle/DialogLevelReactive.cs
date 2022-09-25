using Architecture;
using UnityEngine;

public abstract class DialogLevelReactive : TileObject
{
    [SerializeField]
    private float threshold;

    private void OnEnable()
    {
        DialogLevelManager.Instance.onSetDialogLevel += CheckForReaction;
    }

    private void OnDisable()
    {
        if(DialogLevelManager.Instance)
            DialogLevelManager.Instance.onSetDialogLevel -= CheckForReaction;
    }

    private void CheckForReaction(float dialogLevel)
    {
        if (dialogLevel >= threshold)
        {
            ThresholdReachedReaction();
        }
        else
        {
            UnderThresholdReaction();
        }
    }

    protected abstract void UnderThresholdReaction();
    protected abstract void ThresholdReachedReaction();
}
