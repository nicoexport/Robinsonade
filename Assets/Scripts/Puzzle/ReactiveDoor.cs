using Architecture;
using UnityEngine;

public class ReactiveDoor : DialogLevelReactive
{
    [SerializeField]
    private TileObject leftDoor;
    [SerializeField]
    private TileObject rightDoor;

    [SerializeField]
    private Color closedColor;
    [SerializeField]
    private Color openColor;

    private SpriteRenderer _leftSpriteRenderer;
    private SpriteRenderer _rightSpriteRenderer;

    private bool isOpen;

    private void OnValidate()
    {
        _leftSpriteRenderer = leftDoor.GetComponentInChildren<SpriteRenderer>();
        _leftSpriteRenderer.color = closedColor;
        _rightSpriteRenderer = rightDoor.GetComponentInChildren<SpriteRenderer>();
        _rightSpriteRenderer.color = closedColor;
    }

    public override void Initialize()
    {
        TileManager.Instance.SnapToGrid(gameObject);
    }

    protected override void ThresholdReachedReaction()
    {
        if (!isOpen)
        {
            MoveDoor(leftDoor, -1, 1f);
            MoveDoor(rightDoor, 1, 1f);
            ChangeDoorColor(openColor);
            isOpen = true;
        }
    }

    protected override void UnderThresholdReaction()
    {
        if (isOpen)
        {
            MoveDoor(leftDoor, 1, 1f);
            MoveDoor(rightDoor, -1, 1f);
            ChangeDoorColor(closedColor);
            isOpen = false;
        }
    }

    private void MoveDoor(TileObject doorPart, int unitsToMove, float timeInSeconds)
    {
        doorPart.UnregisterTileObject();
        var target = doorPart.transform.position + doorPart.transform.right * unitsToMove;
        LeanTween.move(doorPart.gameObject, target, timeInSeconds).setOnComplete(() => CompleteMoveDoor(doorPart));
    }

    private void ChangeDoorColor(Color changeToColor)
    {
        LeanTween.color(_leftSpriteRenderer.gameObject, changeToColor, 1f);
        LeanTween.color(_rightSpriteRenderer.gameObject, changeToColor, 1f);
    }

    private void CompleteMoveDoor(TileObject doorPart)
    {
        doorPart.RegisterTileObject();
    }
}
