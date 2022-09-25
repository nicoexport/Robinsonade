using Architecture;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Socket))]
public class ReactiveSocket : DialogLevelReactive
{
    [SerializeField]
    private Sprite lockedSprite;
    [SerializeField]
    private Sprite unlockedSprite;

    public UnityEvent OnThresholdReached;
    public UnityEvent OnThresholdLost;

    private Socket _socket;
    private SpriteRenderer _spriteRenderer;

    public override void Initialize()
    {
        _socket = GetComponent<Socket>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = lockedSprite;
        _spriteRenderer.sortingLayerName = "Default";
    }

    protected override void ThresholdReachedReaction()
    {
        _spriteRenderer.sprite = unlockedSprite;
        _spriteRenderer.sortingLayerName = "Midground";
        OnThresholdReached?.Invoke();
        _socket.UnlockSocket();
    }

    protected override void UnderThresholdReaction()
    {
        _spriteRenderer.sprite = lockedSprite;
        _spriteRenderer.sortingLayerName = "Default";
        OnThresholdLost?.Invoke();
        _socket.LockSocket();
    }
}
