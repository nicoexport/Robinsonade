using Architecture;
using UnityEngine;

public class ReactiveDoor : DialogLevelReactive
{
    private bool isOpen;

    protected override void ThresholdReachedReaction()
    {
        if (!isOpen)
        {

            MoveDoor(transform.right, 2, 1f);
            isOpen = true;
        }
    }

    protected override void UnderThresholdReaction()
    {
        if (isOpen)
        {
            MoveDoor(transform.right, -2, 1f);
            isOpen = false;
        }
    }

    private void MoveDoor(Vector3 direction, int unitsToMove, float timeInSeconds)
    {
        var target = transform.position + direction * unitsToMove;
        LeanTween.move(gameObject, target, timeInSeconds);
    }
}
