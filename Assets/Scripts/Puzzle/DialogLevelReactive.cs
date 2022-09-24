using Architecture;
using System;
using UnityEngine;

public abstract class DialogLevelReactive : TileObject
{
    [SerializeField]
    private float threshold;

    private void Awake()
    {
        DialogLevelManager.Instance.onSetDialogLevel += CheckForReaction;
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
