using Architecture;
using UnityEngine;

public class ReactiveDoor : DialogLevelReactive
{
    [SerializeField]
    private DefaultTileObject leftDoor;
    [SerializeField]
    private DefaultTileObject rightDoor;

    [SerializeField]
    private Color closedColor;
    [SerializeField]
    private Color openColor;

    [SerializeField]
    private int unitsToMove;

    private Vector3 _leftOriginPosition;
    private Vector3 _leftOpenPosition;
    private Vector3 _rightOriginPosition;
    private Vector3 _rightOpenPosition;

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
        _leftOriginPosition = leftDoor.transform.position;
        _leftOpenPosition = leftDoor.transform.position - leftDoor.transform.right * unitsToMove;
        _rightOriginPosition = rightDoor.transform.position;
        _rightOpenPosition = rightDoor.transform.position + rightDoor.transform.right * unitsToMove;
    }

    protected override void ThresholdReachedReaction()
    {
        if (!isOpen)
        {
            OpenDoor();
            ChangeDoorColor(openColor);
            isOpen = true;
        }
    }

    protected override void UnderThresholdReaction()
    {
        if (isOpen)
        {
            CloseDoor();
            ChangeDoorColor(closedColor);
            isOpen = false;
        }
    }

    private void OpenDoor()
    {
        leftDoor.UnregisterTileObject();
        rightDoor.UnregisterTileObject();
        LeanTween.cancel(leftDoor.gameObject);
        LeanTween.cancel(rightDoor.gameObject);
        LeanTween.move(leftDoor.gameObject, _leftOpenPosition, 1f).setOnComplete(() => CompleteMoveDoor(leftDoor));
        LeanTween.move(rightDoor.gameObject, _rightOpenPosition, 1f).setOnComplete(() => CompleteMoveDoor(rightDoor));
    }

    private void CloseDoor()
    {
        leftDoor.UnregisterTileObject();
        rightDoor.UnregisterTileObject();
        LeanTween.cancel(leftDoor.gameObject);
        LeanTween.cancel(rightDoor.gameObject);
        LeanTween.move(leftDoor.gameObject, _leftOriginPosition, 1f).setOnComplete(() => CompleteMoveDoor(leftDoor));
        LeanTween.move(rightDoor.gameObject, _rightOriginPosition, 1f).setOnComplete(() => CompleteMoveDoor(rightDoor));
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
