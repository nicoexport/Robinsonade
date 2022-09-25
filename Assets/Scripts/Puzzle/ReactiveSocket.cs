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

    private bool _unlocked = false;

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
        if (_unlocked)
            return;
        _spriteRenderer.sprite = unlockedSprite;
        _spriteRenderer.sortingLayerName = "Midground";
        DialogLevelManager.Instance.PlayUnlockAudio();
        _socket.UnlockSocket();
        _unlocked = true;
    }

    protected override void UnderThresholdReaction()
    {
        if (!_unlocked)
            return;
        _spriteRenderer.sprite = lockedSprite;
        _spriteRenderer.sortingLayerName = "Default";
        DialogLevelManager.Instance.PlayLoseUnlockAudio();
        _socket.LockSocket();
        _unlocked = false;
    }
}
